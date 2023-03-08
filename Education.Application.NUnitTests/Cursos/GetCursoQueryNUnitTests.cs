using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class GetCursoQueryNUnitTests
    {
        private GetCursoQuery.GetCursoQueryHandler handlerAllCursos;
        

        [SetUp]
        public void Setup()
        {
            //generar la data de prueba
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            //agregar un record adicional - elemento de curso ID Limpio o vacio 
            cursoRecords.Add(fixture.Build<Curso>()
                .With(tr => tr.CursoId, Guid.NewGuid())
                .Create()
            );

            //creando base de datos en memoria - instancia - Ba
            //base de datos en memoria
            var options = new DbContextOptionsBuilder<EducationDbContext>()
               .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
               .Options;

            //creando dbcontext
            var educationDbContextFake = new EducationDbContext(options);

            //agregando la data de la entidad Cursos
            educationDbContextFake.Cursos.AddRange(cursoRecords);
            educationDbContextFake.SaveChanges();

            //creando mapping
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
                }    
            );
            var mapper = mapConfig.CreateMapper();

            //Instanciar un objeto de la clase GetCursoQuery.GetCursoQueryHandler
            handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(educationDbContextFake, mapper);

        }

        
        [Test]
        public async Task GetCursoQueryHandler_ConsultaCursos_ReturnsTrue()
        {
            // 1. Emular al Context que representa la instancia de EF - Listo


            // 2. Emular al Mapping Profile


            // 3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQueryHandler y pasarle
            // como parametros los objetos context y mapping
            // GetCursoQueryHandler(context, mapping)  => handle

            GetCursoQuery.GetCursoQueryRequest request = new();
            //devuelve el r
            var resultados = await handlerAllCursos.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resultados);
        }
    }
}
