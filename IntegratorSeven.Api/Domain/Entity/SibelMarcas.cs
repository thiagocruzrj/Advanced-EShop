using System;

namespace IntegratorSeven.Api.Domain.Entity {
    public class SibelMarcas {
        public SibelMarcas (long id, string evento, DateTime dtEvento, string cdMarca, string nmMarca, string razaoSocial, string cdGrupoEconomico, string tipoDocumento, string numDocumento, string nnWwebsite, string cdAtuacaoMarca, string cdPerfilSocial, string cdSegmentoAbrasce, string cdCategoriaAbrasce, string flgAntena, string flgCaixaEletronico, string flgMedia, string flgQuiosque, string flgLoja, string flgEvento, string vlFaixaMetragemDe, string vlFaixaMetragemAte, string vlMetragemMinimaEvento, string vlMetragemMinimaQuiosque, string atendimentoLoja, string atendimentoMall, string atendimentoMidia, string kaRespLoja, string kaRespMallMidia, string dtInsert, string dtUpdate) {
            this.Id = id;
            this.Evento = evento;
            this.DtEvento = dtEvento;
            this.CdMarca = cdMarca;
            this.NmMarca = nmMarca;
            this.RazaoSocial = razaoSocial;
            this.CdGrupoEconomico = cdGrupoEconomico;
            this.TipoDocumento = tipoDocumento;
            this.NumDocumento = numDocumento;
            this.NnWwebsite = nnWwebsite;
            this.CdAtuacaoMarca = cdAtuacaoMarca;
            this.CdPerfilSocial = cdPerfilSocial;
            this.CdSegmentoAbrasce = cdSegmentoAbrasce;
            this.CdCategoriaAbrasce = cdCategoriaAbrasce;
            this.FlgAntena = flgAntena;
            this.FlgCaixaEletronico = flgCaixaEletronico;
            this.FlgMedia = flgMedia;
            this.FlgQuiosque = flgQuiosque;
            this.FlgLoja = flgLoja;
            this.FlgEvento = flgEvento;
            this.VlFaixaMetragemDe = vlFaixaMetragemDe;
            this.VlFaixaMetragemAte = vlFaixaMetragemAte;
            this.VlMetragemMinimaEvento = vlMetragemMinimaEvento;
            this.VlMetragemMinimaQuiosque = vlMetragemMinimaQuiosque;
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
        public string CdMarca { get; private set; }
        public string NmMarca { get; private set; }
        public string RazaoSocial { get; private set; }
        public string CdGrupoEconomico { get; private set; }
        public string TipoDocumento { get; private set; }
        public string NumDocumento { get; private set; }
        public string NnWwebsite { get; private set; }
        public string CdAtuacaoMarca { get; private set; }
        public string CdPerfilSocial { get; private set; }
        public string CdSegmentoAbrasce { get; private set; }
        public string CdCategoriaAbrasce { get; private set; }
        public string FlgAntena { get; private set; }
        public string FlgCaixaEletronico { get; private set; }
        public string FlgMedia { get; private set; }
        public string FlgQuiosque { get; private set; }
        public string FlgLoja { get; private set; }
        public string FlgEvento { get; private set; }
        public string VlFaixaMetragemDe { get; private set; }
        public string VlFaixaMetragemAte { get; private set; }
        public string VlMetragemMinimaEvento { get; private set; }
        public string VlMetragemMinimaQuiosque { get; private set; }
        public string AtendimentoLoja { get; private set; }
        public string AtendimentoMall { get; private set; }
        public string AtendimentoMidia { get; private set; }
        public string KaRespLoja { get; private set; }
        public string KaRespMallMidia { get; private set; }
        public string DtInsert { get; private set; }
        public string DtUpdate { get; private set; }
    }
}