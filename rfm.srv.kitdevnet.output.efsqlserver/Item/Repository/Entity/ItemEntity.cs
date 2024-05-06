using System.ComponentModel.DataAnnotations.Schema;

namespace rfm.srv.kitdevnet.output.sqlserver.ef.Item.Repository.Entity
{
    [Table("tb_item")]
    public class ItemEntity
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
