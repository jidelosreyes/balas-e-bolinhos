﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using ApostasBalasDataModel;

namespace ApostasBalasBusinessModel
{
    public sealed class BusinessModel : PlatformModel
    {
        #region Instancia & Contructor

        public static BusinessModel GetInstance { get { return Instance(); } }
        private static BusinessModel LogicModelInstance = null;
        private static BusinessModel Instance()
        {
            if (null == LogicModelInstance)
                LogicModelInstance = new BusinessModel();
            return LogicModelInstance;
        }

        ApostasBalasDBEntities ApostasBalasDB = null;
        private BusinessModel()
        {
            if (ApostasBalasDB == null)
            {
                ApostasBalasDB = new ApostasBalasDBEntities();
            }
        }

        #endregion

        #region Objectos

        public class PrimeiroClassificado
        {
            public string Nome { get; set; }
            public int? Jogos { get; set; }
            public int? Vitorias { get; set; }
            public int? Empates { get; set; }
            public int? Derrotas { get; set; }
            public int? Pontos { get; set; }
        }

        public class InfoJogo
        {
            public string Id { get; set; }
            public string Data { get; set; }
            public string Equipa1 { get; set; }
            public string Equipa2 { get; set; }
            public string Resultado1 { get; set; }
            public string Resultado2 { get; set; }
            public string Realizado { get; set; }
            public string TotalPontos { get; set; }
        }

        public class CompeticaoRegistada
        {
            public string Descricao { get; set; }
            public int? IdUtilizador { get; set; }
            public int? IdCompeticao { get; set; }
            public bool? Activo { get; set; }
        }

        #endregion

        #region Login

        public bool Login(string Email, string Password, bool Lembrarme)
        {
            try
            {
                var Utilizador = ApostasBalasDB.Utilizador.Where(u => u.Email == Email & u.Password == Password & u.Activo == true).SingleOrDefault();
                if (Utilizador != null)
                {
                    NomeUtilizadorSessao = Utilizador.NomeUtilizador;
                    PasswordSessao = Utilizador.Password;
                    IdUtilizadorSessao = Utilizador.IdUtilizador.ToString();
                    HttpContext.Current.Session.Timeout = ConstantsModel.SessionTimeOut;
                    if (Lembrarme)
                    {
                        HttpCookie Cookie = new HttpCookie(ConstantsModel.CookieName);
                        Cookie.Value = IdUtilizadorSessao;
                        Cookie.Expires = DateTime.Now.AddDays(5);
                        HttpContext.Current.Response.Cookies.Add(Cookie);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void RegistarUtilizador(string Email, string Nome, string Password)
        {
            try
            {
                var Utilizador = new Utilizador()
                {
                    Activo = false,
                    Administrador = false,
                    DataActualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    Email = Email,
                    NomeUtilizador = Nome,
                    Password = Password
                };
                ApostasBalasDB.Utilizador.AddObject(Utilizador);
                ApostasBalasDB.SaveChanges();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void RecuperarPassword(string Email)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void LogOut()
        {
            try
            {
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                if (IsCookie)
                {
                    HttpCookie Cookie = new HttpCookie(ConstantsModel.CookieName);
                    Cookie.Expires = DateTime.Now.AddDays(-1d);
                    HttpContext.Current.Response.Cookies.Add(Cookie);
                }
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void CookieLogin()
        {
            try
            {
                var IdUtilizador = Int32.Parse(HttpContext.Current.Request.Cookies[ConstantsModel.CookieName].Value.ToString());
                var Utilizador = ApostasBalasDB.Utilizador.Where(u => u.IdUtilizador == IdUtilizador).SingleOrDefault();
                NomeUtilizadorSessao = Utilizador.NomeUtilizador;
                PasswordSessao = Utilizador.Password;
                IdUtilizadorSessao = Utilizador.IdUtilizador.ToString();
                Session.Timeout = ConstantsModel.SessionTimeOut;
                HttpContext.Current.Response.RedirectToRoute(ConstantsModel.HomeRoute);
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void VerificarSessao()
        {
            try
            {
                if (NomeUtilizadorSessao != string.Empty & PasswordSessao != string.Empty & IdUtilizadorSessao != string.Empty)
                {
                    return;
                }
                if (IsCookie)
                {
                    CookieLogin();
                }
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        #endregion

        #region Master

        public Noticia ObterUltimaNoticia()
        {
            try
            {
                return ApostasBalasDB.Noticia
                    .OrderByDescending(n => n.DataCriacao)
                    .FirstOrDefault();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public List<InfoJogo> ObterUltimaJornada()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var CompeticaoActiva = ApostasBalasDB.UtilizadorCompeticao
                    .Where(uc => uc.IdUtilizador == Id & uc.Activo == true)
                    .Select(uc => uc.IdCompeticao)
                    .FirstOrDefault();
                var UltimaJornada = ApostasBalasDB.Jornada
                    .OrderByDescending(j => j.IdJornada)
                    .Where(j => j.IdCompeticao == CompeticaoActiva)
                    .Select(j => j.IdJornada)
                    .FirstOrDefault();
                var Jogos = ApostasBalasDB.Jogo
                     .Join(ApostasBalasDB.JornadaJogoCompeticao, j => j.IdJogo, jc => jc.IdJogo, (j, jc) => new { j, jc })
                     .Where(jc => jc.jc.IdCompeticao == CompeticaoActiva && jc.jc.IdJornada == UltimaJornada && jc.j.Realizado == true)
                     .Select(j => j.j).ToList();
                var UltimoResultado = new List<InfoJogo>();
                foreach (var item in Jogos)
                {
                    string[] Equipas = item.Descricao.Split(ConstantsModel.Delimiter);
                    string[] Resultados = item.Resultado.Split(ConstantsModel.Delimiter);
                    UltimoResultado.Add(new InfoJogo
                    {
                        Equipa1 = Equipas[0],
                        Equipa2 = Equipas[1],
                        Resultado1 = Resultados[0],
                        Resultado2 = Resultados[1]
                    });
                }
                return UltimoResultado;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public string ObterNomeUtilizador()
        {
            try
            {
                if (NomeUtilizadorSessao != string.Empty & PasswordSessao != string.Empty & IdUtilizadorSessao != string.Empty)
                {
                    return NomeUtilizadorSessao;
                }
                return string.Empty;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public bool? ObterUtilizadorAdmin()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                return ApostasBalasDB.Utilizador.Where(u => u.IdUtilizador == Id && u.Activo == true).SingleOrDefault().Administrador;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        #endregion

        #region Home

        public List<PrimeiroClassificado> ObterPrimeirosClassificados()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var IdCompeticaActiva = ApostasBalasDB.UtilizadorCompeticao
                   .Where(uc => uc.IdUtilizador == Id && uc.Activo == true)
                   .Select(uc => uc.IdCompeticao)
                   .FirstOrDefault();
                var _PrimeirosClassificados = ApostasBalasDB.Classificacao
                    .Join(ApostasBalasDB.Utilizador, c => c.IdUtilizador, u => u.IdUtilizador, (c, u) => new { c, u })
                    .Join(ApostasBalasDB.UtilizadorCompeticao, uuc => uuc.u.IdUtilizador, uc => uc.IdUtilizador, (uuc, uc) => new { uuc, uc })
                    .Where(w => w.uc.IdCompeticao == IdCompeticaActiva && w.uc.Activo == true)
                    .Select(pc => new PrimeiroClassificado
                    {
                        Nome = pc.uuc.u.NomeUtilizador,
                        Derrotas = pc.uuc.c.Derrotas,
                        Empates = pc.uuc.c.Empates,
                        Jogos = pc.uuc.c.Jogos,
                        Pontos = pc.uuc.c.Pontos,
                        Vitorias = pc.uuc.c.Vitorias
                    }).OrderByDescending(o => o.Pontos).Take(5).ToList();
                return _PrimeirosClassificados;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public string ObterNomeCompeticaoActiva()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var NomeCompeticao = ApostasBalasDB.UtilizadorCompeticao
                    .Join(ApostasBalasDB.Competicao, uc => uc.IdCompeticao, c => c.IdCompeticao, (uc, c) => new { uc, c })
                    .Where(uc => uc.uc.IdUtilizador == Id && uc.uc.Activo == true)
                    .Select(c => c.c.Descricao)
                    .FirstOrDefault();

                return NomeCompeticao;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        #endregion

        #region Competicoes

        public List<Competicao> ObterCompeticoes()
        {
            try
            {
                return ApostasBalasDB.Competicao
                    .OrderBy(c => c.IdCompeticao)
                    .ToList();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public List<CompeticaoRegistada> ObterCompeticoesRegistadas()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                return ApostasBalasDB.Competicao
                    .Join(ApostasBalasDB.UtilizadorCompeticao, c => c.IdCompeticao, uc => uc.IdCompeticao, (c, uc) => new { c, uc })
                    .Where(uc => uc.uc.IdUtilizador == Id)
                    .OrderByDescending(c => c.c.IdCompeticao)
                    .Select(c => new CompeticaoRegistada
                    {
                        Descricao = c.c.Descricao,
                        Activo = c.uc.Activo,
                        IdCompeticao = c.c.IdCompeticao,
                        IdUtilizador = c.uc.IdUtilizador
                    })
                    .ToList();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void RegistarCompeticao(string IdCompeticao)
        {
            try
            {
                ApostasBalasDB.UtilizadorCompeticao.AddObject(new UtilizadorCompeticao
                {
                    IdCompeticao = Int32.Parse(IdCompeticao),
                    IdUtilizador = Int32.Parse(IdUtilizadorSessao),
                    Activo = false,
                    DataActualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now
                });
                ApostasBalasDB.SaveChanges();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void ActivarCompeticao(string IdCompeticao)
        {
            try
            {
                var Id = Int32.Parse(IdCompeticao);
                var IdUtilizador = Int32.Parse(IdUtilizadorSessao);
                var _CompeticaoActiva = ApostasBalasDB.UtilizadorCompeticao
                    .Where(uc => uc.IdCompeticao == Id && uc.IdUtilizador == IdUtilizador)
                    .FirstOrDefault();
                _CompeticaoActiva.Activo = true;
                ApostasBalasDB.UtilizadorCompeticao.ApplyCurrentValues(_CompeticaoActiva);

                var _CompeticoesDesactivar = ApostasBalasDB.UtilizadorCompeticao
                    .Where(uc => uc.IdCompeticao != Id && uc.IdUtilizador == IdUtilizador)
                    .ToList();
                foreach (var item in _CompeticoesDesactivar)
                {
                    item.Activo = false;
                    ApostasBalasDB.UtilizadorCompeticao.ApplyCurrentValues(item);
                }

                ApostasBalasDB.SaveChanges();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        #endregion

        #region Apostas

        public List<Jornada> ObterJornadas()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var IdCompeticaActiva = ApostasBalasDB.UtilizadorCompeticao
                    .Where(uc => uc.IdUtilizador == Id && uc.Activo == true)
                    .Select(uc => uc.IdCompeticao)
                    .FirstOrDefault();
                return ApostasBalasDB.Jornada
                    .OrderBy(j => j.Descricao)
                    .Where(j => j.IdCompeticao == IdCompeticaActiva)
                    .ToList();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public List<Jornada> ObterJornadasAnteriores()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var IdCompeticaActiva = ApostasBalasDB.UtilizadorCompeticao
                    .Where(uc => uc.IdUtilizador == Id && uc.Activo == true)
                    .Select(uc => uc.IdCompeticao)
                    .FirstOrDefault();
                var Total = ApostasBalasDB.Jornada
                    .OrderBy(j => j.Descricao)
                    .Where(j => j.IdCompeticao == IdCompeticaActiva)
                    .Count();
                return ApostasBalasDB.Jornada
                    .OrderBy(j => j.Descricao)
                    .Where(j => j.IdCompeticao == IdCompeticaActiva)
                    .Take(Total - 1)
                    .ToList();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public List<InfoJogo> ObterJornadaById(string IdJornada)
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var _IdJornada = Int32.Parse(IdJornada);
                var CompeticaoActiva = ApostasBalasDB.UtilizadorCompeticao.Where(uc => uc.IdUtilizador == Id & uc.Activo == true).Select(uc => uc.IdCompeticao).FirstOrDefault();
                var Jornada = ApostasBalasDB.Jornada
                    .Where(j => j.IdCompeticao == CompeticaoActiva && j.IdJornada == _IdJornada)
                    .Select(j => j.IdJornada)
                    .FirstOrDefault();
                var Jogos = ApostasBalasDB.Jogo
                     .Join(ApostasBalasDB.JornadaJogoCompeticao, j => j.IdJogo, jc => jc.IdJogo, (j, jc) => new { j, jc })
                     .Where(jc => jc.jc.IdCompeticao == CompeticaoActiva && jc.jc.IdJornada == Jornada && jc.j.Realizado == true)
                     .Select(j => j.j).ToList();
                
                var UltimoResultado = new List<InfoJogo>();
                foreach (var item in Jogos)
                {
                    string[] Equipas = item.Descricao.Split(ConstantsModel.Delimiter);
                    string[] Resultados = item.Resultado.Split(ConstantsModel.Delimiter);
                    UltimoResultado.Add(new InfoJogo
                    {
                        Equipa1 = Equipas[0],
                        Equipa2 = Equipas[1],
                        Resultado1 = Resultados[0],
                        Resultado2 = Resultados[1]
                    });
                }
                return UltimoResultado;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void CalcularPontosJornada()
        {
            var Dados = ApostasBalasDB.Aposta
                .Join(ApostasBalasDB.JornadaJogoCompeticao, a => a.IdJornadaJogoCompeticao, jjc => jjc.IdJornadaJogoCompeticao, (a, jjc) => new { a, jjc })
                .Join(ApostasBalasDB.Jogo, jjc => jjc.jjc.IdJogo, j => j.IdJogo, (jjc, j) => new { jjc, j })
                .Where(w => w.jjc.a.IdUtilizador == 1 && w.jjc.jjc.IdCompeticao == 1 && w.jjc.jjc.IdJornada == 1 && w.j.Realizado == true)
                .ToList();
            Dictionary<int, int> Pontos = new Dictionary<int, int>();
            foreach (var item in Dados)
            {
                string[] Aposta = item.jjc.a.Descricao.Split(ConstantsModel.Delimiter);
                string[] Resultado = item.j.Resultado.Split(ConstantsModel.Delimiter);

                if (Aposta.Equals(Resultado))
                {
                    Pontos.Add(item.j.IdJogo, 3);
                    continue;
                }
                if (Int32.Parse(Aposta[0]) > Int32.Parse(Aposta[1]) && Int32.Parse(Resultado[0]) > Int32.Parse(Resultado[1]))
                {
                    Pontos.Add(item.j.IdJogo, 1);
                    continue;
                }
                if (Int32.Parse(Aposta[0]) < Int32.Parse(Aposta[1]) && Int32.Parse(Resultado[0]) < Int32.Parse(Resultado[1]))
                {
                    Pontos.Add(item.j.IdJogo, 1);
                    continue;
                }
                if (Int32.Parse(Aposta[0]) == Int32.Parse(Aposta[1]) && Int32.Parse(Resultado[0]) == Int32.Parse(Resultado[1]))
                {
                    Pontos.Add(item.j.IdJogo, 1);
                    continue;
                }
            }
        }

        public List<InfoJogo> ObterJogosApostar(string IdJornada)
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var _IdJornada = Int32.Parse(IdJornada);
                var CompeticaoActiva = ApostasBalasDB.UtilizadorCompeticao
                    .Where(uc => uc.IdUtilizador == Id & uc.Activo == true)
                    .Select(uc => uc.IdCompeticao)
                    .FirstOrDefault();
                var Jogos = ApostasBalasDB.Jogo
                    .Join(ApostasBalasDB.JornadaJogoCompeticao, j => j.IdJogo, jjc => jjc.IdJogo, (j, jjc) => new { j, jjc })
                    .Where(r => r.jjc.IdJornada == _IdJornada && r.jjc.IdCompeticao == CompeticaoActiva)
                    .ToList();
                var InfoJogos = new List<InfoJogo>();
                foreach (var item in Jogos)
                {
                    //if (item.j.Resultado == null) { item.j.Resultado = ConstantsModel.NullResult; }
                    string[] Equipas = item.j.Descricao.Split(ConstantsModel.Delimiter);
                    //string[] Resultados = item.j.Resultado.Split(ConstantsModel.Delimiter);
                    InfoJogos.Add(new InfoJogo
                    {
                        Id = item.jjc.IdJornadaJogoCompeticao.ToString(),
                        Data = item.j.Data.ToString(),
                        Realizado = item.j.Realizado.ToString(),
                        Equipa1 = Equipas[0],
                        Equipa2 = Equipas[1],
                        Resultado1 = ConstantsModel.Zero,
                        Resultado2 = ConstantsModel.Zero
                    });
                }
                foreach (var item in InfoJogos)
                {
                    var IdJornadaJogoCompeticao = Int32.Parse(item.Id);
                    var Aposta = ApostasBalasDB.Aposta
                    .Where(a => a.IdUtilizador == Id && a.IdJornadaJogoCompeticao == IdJornadaJogoCompeticao)
                    .Select(a => a.Descricao)
                    .FirstOrDefault();
                    if (Aposta != null)
                    {
                        string[] Resultado = Aposta.Split(ConstantsModel.Delimiter);
                        item.Resultado1 = Resultado[0];
                        item.Resultado2 = Resultado[1];
                    }
                    if (Aposta == null && bool.Parse(item.Realizado) == false)
                    {
                        item.Resultado1 = ConstantsModel.Zero;
                        item.Resultado2 = ConstantsModel.Zero;
                    }
                }
                return InfoJogos;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }

        }

        public void Apostar(string Id, string Resultado1, string Resultado2)
        {
            try
            {
                var _Id = Int32.Parse(IdUtilizadorSessao);
                var _IdJornadaJogoCompeticao = Int32.Parse(Id);
                string Descricao = Resultado1 + "-" + Resultado2;
                var iExiste = ApostasBalasDB.Aposta
                    .Where(a => a.IdJornadaJogoCompeticao == _IdJornadaJogoCompeticao && a.IdUtilizador == _Id)
                    .FirstOrDefault();
                if (iExiste != null)
                {
                    iExiste.Descricao = Descricao;
                    iExiste.DataActualizacao = DateTime.Now;
                    ApostasBalasDB.Aposta.ApplyCurrentValues(iExiste);
                }
                else
                {
                    ApostasBalasDB.Aposta.AddObject(new Aposta
                    {
                        DataActualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now,
                        Descricao = Descricao,
                        IdJornadaJogoCompeticao = _IdJornadaJogoCompeticao,
                        IdUtilizador = _Id
                    });
                }
                ApostasBalasDB.SaveChanges();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        #endregion

        #region Classificacao



        #endregion

        #region Estatisticas



        #endregion

        #region Admin



        #endregion
    }    
}
