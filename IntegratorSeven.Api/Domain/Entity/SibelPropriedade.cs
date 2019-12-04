using System;

namespace IntegratorSeven.Api.Domain.Entity {
    public class SibelPropriedade {
        public SibelPropriedade (long id, string evento, DateTime dtEvento, string cdPropriedade, string tipoPropriedade, string origdCpiAssociada, string indStatus, string indSituacao, string indDisponibLocacao, string categoriaPropriedade, string indAlerta, string classificacaoAbc, string abl, string vlCrd, string tipoMaterial, string tipoEstrutura, string periodoVenda, string tipoVenda, string qtdComercializada, string dlUltUpdValores, string ultimoAluguelFatur, string ultimoAluguelPercent, string ultimoAluguelMinimo, string ultimoAluguelContrato, string ultimoCondominio, string ultimoFundoPromo, string ultimoAtividade, string ultimoLogista, string dtSaidaLogista, string anmTotalPrimeiroAnoViab, string anmTotalViab, string aluguelM2PrimeiroAnoViab, string primeiroNOmeViaB, string cduM2ViaB, string cduViaB, string numAlugueisAnoViaB, string condominioViaB, string vglViaB, string previsaoSegmtoViaB, string aluguelM2PrimeiroAnoTab, string aluguelPrimeiroAnoTab, string cduM2Tab, string cduTab, string vglTab, string setorLocalizacao, string pavimento_Localizacao, string cdCpiAssociada, string dt_Insert, string dt_Update, string ind_Reserva_Tecnica, string dtIniReforma, string dtFimReforma) {
            this.Id = id;
            this.Evento = evento;
            this.DtEvento = dtEvento;
            this.CdPropriedade = cdPropriedade;
            this.TipoPropriedade = tipoPropriedade;
            this.OrigdCpiAssociada = origdCpiAssociada;
            this.IndStatus = indStatus;
            this.IndSituacao = indSituacao;
            this.IndDisponibLocacao = indDisponibLocacao;
            this.CategoriaPropriedade = categoriaPropriedade;
            this.IndAlerta = indAlerta;
            this.ClassificacaoAbc = classificacaoAbc;
            this.Abl = abl;
            this.VlCrd = vlCrd;
            this.TipoMaterial = tipoMaterial;
            this.TipoEstrutura = tipoEstrutura;
            this.PeriodoVenda = periodoVenda;
            this.TipoVenda = tipoVenda;
            this.QtdComercializada = qtdComercializada;
            this.DlUltUpdValores = dlUltUpdValores;
            this.UltimoAluguelFatur = ultimoAluguelFatur;
            this.UltimoAluguelPercent = ultimoAluguelPercent;
            this.UltimoAluguelMinimo = ultimoAluguelMinimo;
            this.UltimoAluguelContrato = ultimoAluguelContrato;
            this.UltimoCondominio = ultimoCondominio;
            this.UltimoFundoPromo = ultimoFundoPromo;
            this.UltimoAtividade = ultimoAtividade;
            this.UltimoLogista = ultimoLogista;
            this.DtSaidaLogista = dtSaidaLogista;
            this.AnmTotalPrimeiroAnoViab = anmTotalPrimeiroAnoViab;
            this.AnmTotalViab = anmTotalViab;
            this.AluguelM2PrimeiroAnoViab = aluguelM2PrimeiroAnoViab;
            this.PrimeiroNOmeViaB = primeiroNOmeViaB;
            this.CduM2ViaB = cduM2ViaB;
            this.CduViaB = cduViaB;
            this.NumAlugueisAnoViaB = numAlugueisAnoViaB;
            this.CondominioViaB = condominioViaB;
            this.VglViaB = vglViaB;
            this.PrevisaoSegmtoViaB = previsaoSegmtoViaB;
            this.AluguelM2PrimeiroAnoTab = aluguelM2PrimeiroAnoTab;
            this.AluguelPrimeiroAnoTab = aluguelPrimeiroAnoTab;
            this.CduM2Tab = cduM2Tab;
            this.CduTab = cduTab;
            this.VglTab = vglTab;
            this.SetorLocalizacao = setorLocalizacao;
            this.Pavimento_Localizacao = pavimento_Localizacao;
            this.CdCpiAssociada = cdCpiAssociada;
            this.Dt_Insert = dt_Insert;
            this.Dt_Update = dt_Update;
            this.Ind_Reserva_Tecnica = ind_Reserva_Tecnica;
            this.DtIniReforma = dtIniReforma;
            this.DtFimReforma = dtFimReforma;

        }
        public long Id { get; private set; }
        public string Evento { get; private set; }
        public DateTime DtEvento { get; private set; }
        public string CdPropriedade { get; private set; }
        public string TipoPropriedade { get; private set; }
        public string OrigdCpiAssociada { get; private set; }
        public string IndStatus { get; private set; }
        public string IndSituacao { get; private set; }
        public string IndDisponibLocacao { get; private set; }
        public string CategoriaPropriedade { get; private set; }
        public string IndAlerta { get; private set; }
        public string ClassificacaoAbc { get; private set; }
        public string Abl { get; private set; }
        public string VlCrd { get; private set; }
        public string TipoMaterial { get; private set; }
        public string TipoEstrutura { get; private set; }
        public string PeriodoVenda { get; private set; }
        public string TipoVenda { get; private set; }
        public string QtdComercializada { get; private set; }
        public string DlUltUpdValores { get; private set; }
        public string UltimoAluguelFatur { get; private set; }
        public string UltimoAluguelPercent { get; private set; }
        public string UltimoAluguelMinimo { get; private set; }
        public string UltimoAluguelContrato { get; private set; }
        public string UltimoCondominio { get; private set; }
        public string UltimoFundoPromo { get; private set; }
        public string UltimoAtividade { get; private set; }
        public string UltimoLogista { get; private set; }
        public string DtSaidaLogista { get; private set; }
        public string AnmTotalPrimeiroAnoViab { get; private set; }
        public string AnmTotalViab { get; private set; }
        public string AluguelM2PrimeiroAnoViab { get; private set; }
        public string PrimeiroNOmeViaB { get; private set; }
        public string CduM2ViaB { get; private set; }
        public string CduViaB { get; private set; }
        public string NumAlugueisAnoViaB { get; private set; }
        public string CondominioViaB { get; private set; }
        public string VglViaB { get; private set; }
        public string PrevisaoSegmtoViaB { get; private set; }
        public string AluguelM2PrimeiroAnoTab { get; private set; }
        public string AluguelPrimeiroAnoTab { get; private set; }
        public string CduM2Tab { get; private set; }
        public string CduTab { get; private set; }
        public string VglTab { get; private set; }
        public string SetorLocalizacao { get; private set; }
        public string Pavimento_Localizacao { get; private set; }
        public string CdCpiAssociada { get; private set; }
        public string Dt_Insert { get; private set; }
        public string Dt_Update { get; private set; }
        public string Ind_Reserva_Tecnica { get; private set; }
        public string DtIniReforma { get; private set; }
        public string DtFimReforma { get; private set; }
    }
}