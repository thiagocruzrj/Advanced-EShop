using System;

namespace IntegratorSeven.Api.Domain.Entity
{
    public class SibelCliente
    {
        public SibelCliente(long id, string evento, DateTime dtEvento, string cdCliente, string tipoCliente, string nmRazaoSocial, string cdGrupoEconomico, string cdTipoDocumento, string tipoAgencia, string flgBv, string flgComissoa, string flgAtndMidia, string dtInsert, string dtUpdate, string dsSubtipoCliente, string cdDdd, string nmBairro, string nmCidade, string sgEstado, string nmPais, string cdCep)
        {
            Id = id;
            Evento = evento;
            DtEvento = dtEvento;
            CdCliente = cdCliente;
            TipoCliente = tipoCliente;
            NmRazaoSocial = nmRazaoSocial;
            CdGrupoEconomico = cdGrupoEconomico;
            CdTipoDocumento = cdTipoDocumento;
            TipoAgencia = tipoAgencia;
            FlgBv = flgBv;
            FlgComissoa = flgComissoa;
            FlgAtndMidia = flgAtndMidia;
            DtInsert = dtInsert;
            DtUpdate = dtUpdate;
            DsSubtipoCliente = dsSubtipoCliente;
            CdDdd = cdDdd;
            NmBairro = nmBairro;
            NmCidade = nmCidade;
            SgEstado = sgEstado;
            NmPais = nmPais;
            CdCep = cdCep;
        }

        public long Id { get; private set; }
        public string Evento { get; private set; }
        public DateTime DtEvento { get; private set; }
        public string CdCliente { get; private set; }
        public string TipoCliente { get; private set; }
        public string NmRazaoSocial { get; private set; }
        public string CdGrupoEconomico { get; private set; }
        public string CdTipoDocumento { get; private set; }
        public string TipoAgencia { get; private set; }
        public string FlgBv { get; private set; }
        public string FlgComissoa { get; private set; }
        public string FlgAtndMidia { get; private set; }
        public string DtInsert { get; private set; }
        public string DtUpdate { get; private set; }
        public string DsSubtipoCliente { get; private set; }
        public string CdDdd { get; private set; }
        public string NmBairro { get; private set; }
        public string NmCidade { get; private set; }
        public string SgEstado { get; private set; }
        public string NmPais { get; private set; }
        public string CdCep { get; private set; }
    }
}