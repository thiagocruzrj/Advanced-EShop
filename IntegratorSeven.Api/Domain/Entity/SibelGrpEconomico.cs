using System;

namespace IntegratorSeven.Api.Domain.Entity {
    public class SibelGrpEconomico {
        public SibelGrpEconomico (long id, string evento, DateTime dtEvento, string cdGrpEconomico, string nmGrpEconimico, string razaoSocial, string tipoDocumento, string numDocumento, string nmWebsite, string cdAtuacaoMarca, string atendimentoLoja, string atendimentoMall, string atendimentoMidia, string kaRespLoja, string kaRespMallMidia, string dtInsert, string dtUpdate) {
            this.Id = id;
            this.Evento = evento;
            this.DtEvento = dtEvento;
            this.CdGrpEconomico = cdGrpEconomico;
            this.NmGrpEconimico = nmGrpEconimico;
            this.RazaoSocial = razaoSocial;
            this.TipoDocumento = tipoDocumento;
            this.NumDocumento = numDocumento;
            this.NmWebsite = nmWebsite;
            this.CdAtuacaoMarca = cdAtuacaoMarca;
            this.AtendimentoLoja = atendimentoLoja;
            this.AtendimentoMall = atendimentoMall;
            this.AtendimentoMidia = atendimentoMidia;
            this.KaRespLoja = kaRespLoja;
            this.KaRespMallMidia = kaRespMallMidia;
            this.DtInsert = dtInsert;
            this.DtUpdate = dtUpdate;

        }
        public long Id { get; private set; }
        public string Evento { get; private set; }
        public DateTime DtEvento { get; private set; }
        public string CdGrpEconomico { get; private set; }
        public string NmGrpEconimico { get; private set; }
        public string RazaoSocial { get; private set; }
        public string TipoDocumento { get; private set; }
        public string NumDocumento { get; private set; }
        public string NmWebsite { get; private set; }
        public string CdAtuacaoMarca { get; private set; }
        public string AtendimentoLoja { get; private set; }
        public string AtendimentoMall { get; private set; }
        public string AtendimentoMidia { get; private set; }
        public string KaRespLoja { get; private set; }
        public string KaRespMallMidia { get; private set; }
        public string DtInsert { get; private set; }
        public string DtUpdate { get; private set; }
    }
}