using System;

namespace IntegratorSeven.Api.Domain.Entity {
    public class SibelSegmtoAbrasce {
        public SibelSegmtoAbrasce (long id, string evento, DateTime dtEvento, string cdSegmtoAbrasce, string nmSegmtoAbrasce) {
            this.Id = id;
            this.Evento = evento;
            this.DtEvento = dtEvento;
            this.CdSegmtoAbrasce = cdSegmtoAbrasce;
            this.NmSegmtoAbrasce = nmSegmtoAbrasce;

        }
        public long Id { get; private set; }
        public string Evento { get; private set; }
        public DateTime DtEvento { get; private set; }
        public string CdSegmtoAbrasce { get; private set; }
        public string NmSegmtoAbrasce { get; private set; }
    }
}