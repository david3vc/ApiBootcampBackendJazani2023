using AutoFixture;
using AutoMapper;
using Jazani.Application.Dls.Dtos.Documents;
using Jazani.Application.Dls.Dtos.Documents.Profiles;
using Jazani.Application.Dls.Services;
using Jazani.Application.Dls.Services.Implementations;
using Jazani.Domain.Dls.Models;
using Jazani.Domain.Dls.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Jazani.UnitTest.Application.Dls.Services
{
    public class DocumentServiceTest
    {
        Mock<IDocumentRepository> _mockDocumentRepository;
        Mock<ILogger<DocumentService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public DocumentServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<DocumentProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mockDocumentRepository = new Mock<IDocumentRepository>();

            _mockILogger = new Mock<ILogger<DocumentService>>();
        }

        [Fact]
        public async void returnDocumentDtoWhenFindByIdAsync()
        {
            Document document = _fixture.Create<Document>();


            _mockDocumentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(document);

            // Act
            IDocumentService documentService = new DocumentService(_mockDocumentRepository.Object, _mapper, _mockILogger.Object);

            DocumentDto documentDto = await documentService.FindByIdAsync(document.Id);

            // Assert

            Assert.Equal(document.Name, documentDto.Name);
        }

        [Fact]
        public async void returnDocumentsDtoWhenreFindAllAsync()
        {
            // Arrays
            IReadOnlyList<Document> documents = _fixture.CreateMany<Document>(5).ToList();

            _mockDocumentRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(documents);


            // Act
            IDocumentService documentService = new DocumentService(_mockDocumentRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<DocumentDto> documentDtos = await documentService.FindAllAsync();

            // Assert
            Assert.Equal(documents.Count, documentDtos.Count);
        }

        [Fact]
        public async void returnDocumentDtoWhenCreateAsync()
        {
            // Arrage

            Document document = new()
            {
                Id = 1,
                Name = "M20080430A.pdf",
                Description = "M20080430A",
                IsFile = true,
                ExternalId = 2960,
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockDocumentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Document>()))
                .ReturnsAsync(document);

            // Act

            DocumentSaveDto documentSaveDto = new()
            {
                Name = document.Name,
                Description = document.Description,
                IsFile = document.IsFile,
                ExternalId = document.ExternalId,
            };

            IDocumentService documentService = new DocumentService(_mockDocumentRepository.Object, _mapper, _mockILogger.Object);

            DocumentDto documentDto = await documentService.CreateAsync(documentSaveDto);

            // Assert

            Assert.Equal(document.Name, documentDto.Name);
        }

        [Fact]
        public async void returnDocumentDtoWhenEditAsync()
        {
            // Arrage
            int id = 1;
            Document document = new()
            {
                Id = id,
                Name = "M20080430A.pdf",
                Description = "M20080430A",
                IsFile = true,
                ExternalId = 2960,
                State = true,
                RegistrationDate = DateTime.Now
            };
            _mockDocumentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(document);

            _mockDocumentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Document>()))
                .ReturnsAsync(document);


            // Act

            DocumentSaveDto documentSaveDto = new()
            {
                Name = document.Name,
                Description = document.Description,
                IsFile = document.IsFile,
                ExternalId = document.ExternalId,
            };

            IDocumentService documentService = new DocumentService(_mockDocumentRepository.Object, _mapper, _mockILogger.Object);

            DocumentDto documentDto = await documentService.EditAsync(id, documentSaveDto);

            // Assert

            Assert.Equal(document.Id, documentDto.Id);
        }

        [Fact]
        public async void returnDocumentDtoWhenDisabledAsync()
        {
            // Arrage
            int id = 1;
            Document document = new()
            {
                Id = id,
                Name = "M20080430A.pdf",
                Description = "M20080430A",
                IsFile = true,
                ExternalId = 2960,
                State = true,
                RegistrationDate = DateTime.Now
            };
            _mockDocumentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(document);

            _mockDocumentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Document>()))
                .ReturnsAsync(document);


            // Act

            IDocumentService documentService = new DocumentService(_mockDocumentRepository.Object, _mapper, _mockILogger.Object);

            DocumentDto documentDto = await documentService.DisabledAsync(id);

            // Assert

            Assert.Equal(document.State, documentDto.State);
        }
    }
}
