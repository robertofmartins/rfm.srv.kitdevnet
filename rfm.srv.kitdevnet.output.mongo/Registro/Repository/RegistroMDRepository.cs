using MongoDB.Driver;
using rfm.srv.kitdevnet.domain.models.Registro;
using rfm.srv.kitdevnet.output.mongo.commons;
using rfm.srv.kitdevnet.output.mongo.Registro.Repository.Entity;
using rfm.srv.kitdevnet.output.mongo.Registro.Repository.Mapper;

namespace rfm.srv.kitdevnet.output.mongo.Registro.Repository
{
    internal class RegistroMDRepository
    {
        private readonly IMongoCollection<RegistroEntity> _registrosCollection;

        private readonly RegistroEntityMapper _registroEntityMapper;

        internal RegistroMDRepository(KitDevNetDatabaseSettings kitDevNetDatabaseSettings)
        {
            _registroEntityMapper = new();

            var mongoClient = new MongoClient(kitDevNetDatabaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(kitDevNetDatabaseSettings.DatabaseName);
            _registrosCollection = mongoDatabase.GetCollection<RegistroEntity>("Registros");
        }

        internal async Task<Guid> Atualizar(Guid id, RegistroCriarModel model)
        {
            var ent = await _registroEntityMapper.toEntidade(model);
            ent.Id = id.ToString();
            await _registrosCollection.ReplaceOneAsync(x => x.Id == id.ToString(), ent);
            return id;
        }

        internal async Task<Guid> Criar(RegistroCriarModel model)
        {
            var ent = await _registroEntityMapper.toEntidade(model);
            await _registrosCollection.InsertOneAsync(ent);
            return new Guid(ent.Id);
        }

        internal async Task Excluir(Guid id)
        {
            await _registrosCollection.DeleteOneAsync(x => x.Id == id.ToString());
        }

        internal async Task<List<RegistroModel>> ListarTodos()
        {
            var ents = await _registrosCollection.Find(_ => true).ToListAsync();

            var lst = new List<RegistroModel>();
            foreach (var ent in ents)
            {
                var model = await _registroEntityMapper.toModel(ent);
                lst.Add(model);
            }

            return lst;
        }

        internal async Task<RegistroModel> Obter(Guid id)
        {
            var ent = await _registrosCollection.Find(x => x.Id == id.ToString()).FirstOrDefaultAsync();
            var model = await _registroEntityMapper.toModel(ent);
            return model;
        }
    }
}
