using System;

namespace IntegratorSeven.Api.Domain.Entity {
    public class SibelNegociacao {
        public SibelNegociacao (long id, string evento, DateTime dtEvento, string negociacao, string negociacaoPn, string negociacaoAssoc, string negociacaoCertificada, string marca, string cliente, string shopping, string tipoOportunidade, string estagio, string receitaTotal, string dtEmissao, string tipoPagamento, string aluguelTotal, string energiaTotal, string wishlist, string statusFaturamento, string vlDesconto, string dtIniVigencia, string dtFimVigencia, string categoriaMidia, string ramo, string categoria, string dtVencimento, string dtAssinatura, string motivoReprov, string motivoReprovDoc, string motivoPerde, string dtInsert, string dtUpdate, string dsTpAcaoJuridica) {
            this.Id = id;
            this.Evento = evento;
            this.DtEvento = dtEvento;
            this.Negociacao = negociacao;
            this.NegociacaoPn = negociacaoPn;
            this.NegociacaoAssoc = negociacaoAssoc;
            this.NegociacaoCertificada = negociacaoCertificada;
            this.Marca = marca;
            this.Cliente = cliente;
            this.Shopping = shopping;
            this.TipoOportunidade = tipoOportunidade;
            this.Estagio = estagio;
            this.ReceitaTotal = receitaTotal;
            this.DtEmissao = dtEmissao;
            this.TipoPagamento = tipoPagamento;
            this.AluguelTotal = aluguelTotal;
            this.EnergiaTotal = energiaTotal;
            this.Wishlist = wishlist;
            this.StatusFaturamento = statusFaturamento;
            this.VlDesconto = vlDesconto;
            this.DtIniVigencia = dtIniVigencia;
            this.DtFimVigencia = dtFimVigencia;
            this.CategoriaMidia = categoriaMidia;
            this.Ramo = ramo;
            this.Categoria = categoria;
            this.DtVencimento = dtVencimento;
            this.DtAssinatura = dtAssinatura;
            this.MotivoReprov = motivoReprov;
            this.MotivoReprovDoc = motivoReprovDoc;
            this.MotivoPerde = motivoPerde;
            this.DtInsert = dtInsert;
            this.DtUpdate = dtUpdate;
            this.DsTpAcaoJuridica = dsTpAcaoJuridica;

        }
        public long Id { get; private set; }
        public string Evento { get; private set; }
        public DateTime DtEvento { get; private set; }
        public string Negociacao { get; private set; }
        public string NegociacaoPn { get; private set; }
        public string NegociacaoAssoc { get; private set; }
        public string NegociacaoCertificada { get; private set; }
        public string Marca { get; private set; }
        public string Cliente { get; private set; }
        public string Shopping { get; private set; }
        public string TipoOportunidade { get; private set; }
        public string Estagio { get; private set; }
        public string ReceitaTotal { get; private set; }
        public string DtEmissao { get; private set; }
        public string TipoPagamento { get; private set; }
        public string AluguelTotal { get; private set; }
        public string EnergiaTotal { get; private set; }
        public string Wishlist { get; private set; }
        public string StatusFaturamento { get; private set; }
        public string VlDesconto { get; private set; }
        public string DtIniVigencia { get; private set; }
        public string DtFimVigencia { get; private set; }
        public string CategoriaMidia { get; private set; }
        public string Ramo { get; private set; }
        public string Categoria { get; private set; }
        public string DtVencimento { get; private set; }
        public string DtAssinatura { get; private set; }
        public string MotivoReprov { get; private set; }
        public string MotivoReprovDoc { get; private set; }
        public string MotivoPerde { get; private set; }
        public string DtInsert { get; private set; }
        public string DtUpdate { get; private set; }
        public string DsTpAcaoJuridica { get; private set; }
    }
}