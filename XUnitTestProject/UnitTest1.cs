using Core.Model.Search;
using Data.DataBase;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Services;
using System;
using Xunit;

using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace XUnitTestProject
{
    public class UnitTest1
    {
      
            [Fact]
            public void GetStudentByName_ResultDataShouldNotBeNull()
            {
                //use context with data to run test
                using (var context = SetupAndGetInMemoryDbContext())
                {
                    //Arrange
                    var repository = new StudentRepository(context);
                    var service = new StudentService(repository);

                    //Act
                    var response = service.GetStuentByName(new StuentByNameRequest() { StudentName = "student"}).Result;

                    //Assert
                    Assert.True(response.Success);
                    Assert.NotNull(response.Data);
                }
            }

        [Fact]
        public void GetSubjectByNameandTermRequest_ResultDataShouldNotBeNull()
        {
            //use context with data to run test
            using (var context = SetupAndGetInMemoryDbContext())
            {
                //Arrange
                var repository = new SubjectRepository(context);
                var repository2 = new MarksRepository(context);

                var service = new SubjectService(repository, repository2);

                //Act
                var response = service.GetSubjectBystudentAndTerm(new SubjectByNameandTermRequest() { Student = 1 , Term = 1 }).Result;

                //Assert
                Assert.True(response.Success);
                Assert.NotNull(response.Data);
            }
        }

        private AssessmentProjectDbContext SetupAndGetInMemoryDbContext()
            {
                //Create In-memory database
                var options = new DbContextOptionsBuilder<AssessmentProjectDbContext>()
                    .UseInMemoryDatabase(databaseName: $"OSNInMemoryDb_{Guid.NewGuid()}")
                    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                    .Options;

                //Create Mocked Context and seed data 
                var context = new AssessmentProjectDbContext(options);
                DbInitializer.Initialize(context);

                return context;
            }

        
    }
}
