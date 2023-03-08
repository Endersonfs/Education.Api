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
    public class GetCursoByIdQueryNUnitTests
    {
        private GetCursoByIdQuery.GetCursoByIdQueryHandler handlerByIdCurso;
        private Guid cursoIdTest;


        [SetUp]
        public void Setup()
        {
            cursoIdTest = new Guid("2ce24c4d-df93-4620-ba47-c8065633775f");
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>()
                .With(tr => tr.CursoId, cursoIdTest)
                .Create()
            );


            var options = new DbContextOptionsBuilder<EducationDbContext>()
               .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
               .Options;

            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Cursos.AddRange(cursoRecords);
            educationDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
            }
            );
            var mapper = mapConfig.CreateMapper();

            handlerByIdCurso = new GetCursoByIdQuery.GetCursoByIdQueryHandler(educationDbContextFake, mapper);

        }


        [Test]
        public async Task GetCursoByIdQueryHandler_InputCursoId_ReturnsNotNull()
        {

            GetCursoByIdQuery.GetCursoByIdQueryRequest request = new() { 
                Id = cursoIdTest
            };

            var resultado = await handlerByIdCurso.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resultado);
        }
    }
}
