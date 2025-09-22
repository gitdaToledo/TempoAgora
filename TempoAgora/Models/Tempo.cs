namespace TempoAgora.Models
{
    public class Tempo
    {
        public double? lon { get; set; }
        public double? lat { get; set; }

        //Visibilidade
        public int? visibility { get; set; }

        public double? temp_min { get; set; }
        public double? temp_max { get; set; }

        public string? sunrise { get; set; }
        public string? sunset { get; set; }

        public string? main { get; set; }

        //Descrição do tempo
        public string? descriptionTempo { get; set; }

        //Velocidade do Vento
        public double? speedVento { get; set; }
    }
}



