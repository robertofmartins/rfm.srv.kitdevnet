using rfm.srv.kitdevnet.domain.models.Registro;
using rfm.srv.kitdevnet.output.mongo.Registro.Repository.Entity;

namespace rfm.srv.kitdevnet.output.mongo.Registro.Repository.Mapper
{
    internal class RegistroEntityMapper
    {
        internal async Task<RegistroEntity> toEntidade(RegistroCriarModel model)
        {
            var ent = new RegistroEntity()
            {
                Descricao = model.Descricao,
                Quantidade = model.Quantidade,
                PrecoUnitario = model.PrecoUnitario,
                Ativo = model.Ativo,

                DataCriacao = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
            };

            return ent;
        }

        internal async Task<RegistroModel> toModel(RegistroEntity entity)
        {
            RegistroModel? model = null;
            if (entity != null)
            {
                model = new RegistroModel(
                    Guid.Parse(entity.Id),
                    entity.Descricao,
                    entity.Quantidade,
                    entity.PrecoUnitario,
                    entity.Ativo,
                    entity.DataCriacao);
            }

            return model;
        }
    }


}
