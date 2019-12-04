using System;

namespace IntegratorSeven.Api.Domain.Entity {
    public class SibelCategoriaAbrasce {
        public SibelCategoriaAbrasce (long id, string evento, DateTime dtEvento, string cdCategoriaAbrasce) {
            this.Id = id;
            this.Evento = evento;
            this.DtEvento = dtEvento;
            this.CdCategoriaAbrasce = cdCategoriaAbrasce;

        }
        public long Id { get; private set; }
        public string Evento { get; private set; }
        public DateTime DtEvento { get; private set; }
        public string CdCategoriaAbrasce { get; set; }
        public string NmCategoriaAbrasce { get; set; }
    }
}