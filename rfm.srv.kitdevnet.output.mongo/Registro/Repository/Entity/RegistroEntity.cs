using MongoDB.Bson.Serialization.Attributes;

namespace rfm.srv.kitdevnet.output.mongo.Registro.Repository.Entity
{
    public class RegistroEntity
    {
        [BsonId]
        public string? Id { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
