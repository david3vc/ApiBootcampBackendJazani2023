using AutoFixture;
using AutoMapper;
using Jazani.Application.Mcs.Dtos.Investments;
using Jazani.Application.Mcs.Dtos.Investments.Profiles;
using Jazani.Application.Mcs.Services;
using Jazani.Application.Mcs.Services.Implementations;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Jazani.UnitTest.Application.Mcs.Services
{
    public class InvestmentServiceTest
    {
        Mock<IInvestmentRepository> _mockInvestmentRepository;
        Mock<ILogger<InvestmentService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public InvestmentServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mockInvestmentRepository = new Mock<IInvestmentRepository>();

            _mockILogger = new Mock<ILogger<InvestmentService>>();
        }

        [Fact]
        public async void returnInvestmentDtoWhenFindByIdAsync()
        {
            Investment investment = _fixture.Create<Investment>();


            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            // Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.FindByIdAsync(investment.Id);

            // Assert

            Assert.Equal(investment.AmountInvestd, investmentDto.AmountInvestd);
        }

        [Fact]
        public async void returnInvestmentsDtoWhenreFindAllAsync()
        {
            // Arrays
            IReadOnlyList<Investment> investments = _fixture.CreateMany<Investment>(5).ToList();

            _mockInvestmentRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investments);


            // Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<InvestmentDto> investmentDtos = await investmentService.FindAllAsync();

            // Assert
            Assert.Equal(investments.Count, investmentDtos.Count);
        }

        [Fact]
        public async void returnInvestmentDtoWhenCreateAsync()
        {
            // Arrage

            Investment investment = new()
            {
                Id = 1,
                AmountInvestd = 20,
                Description = "Prueba",
                Year = 2023,
                AccreditationCode = "P2023",
                AccountantCode = "P2023",
                MetricTons = "15",
                MonthName = "Octubre",
                MiningConcessionId = 15,
                HolderId = 4,
                InvestmentTypeId = 12,
                CurrencyTypeId = 2,
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            // Act

            InvestmentSaveDto investmentSaveDto = new()
            {
                AmountInvestd = investment.AmountInvestd,
                Description = investment.Description,
                AccreditationCode = investment.AccreditationCode,
                AccountantCode = investment.AccountantCode,
                MetricTons = investment.MetricTons,
                MonthName = investment.MonthName,
                MiningConcessionId = investment.MiningConcessionId,
                HolderId = investment.HolderId,
                InvestmentTypeId = investment.InvestmentTypeId,
                CurrencyTypeId = investment.CurrencyTypeId,
            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.CreateAsync(investmentSaveDto);

            // Assert

            Assert.Equal(investment.AmountInvestd, investmentDto.AmountInvestd);
        }

        [Fact]
        public async void returnInvestmentDtoWhenEditAsync()
        {
            // Arrage
            int id = 1;
            Investment investment = new()
            {
                Id = id,
                AmountInvestd = 20,
                Description = "Prueba",
                Year = 2023,
                AccreditationCode = "P2023",
                AccountantCode = "P2023",
                MetricTons = "15",
                MonthName = "Octubre",
                MiningConcessionId = 15,
                HolderId = 4,
                InvestmentTypeId = 12,
                CurrencyTypeId = 2,
                State = true,
                RegistrationDate = DateTime.Now
            };
            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);


            // Act

            InvestmentSaveDto investmentSaveDto = new()
            {
                AmountInvestd = investment.AmountInvestd,
                Description = investment.Description,
                AccreditationCode = investment.AccreditationCode,
                AccountantCode = investment.AccountantCode,
                MetricTons = investment.MetricTons,
                MonthName = investment.MonthName,
                MiningConcessionId = investment.MiningConcessionId,
                HolderId = investment.HolderId,
                InvestmentTypeId = investment.InvestmentTypeId,
                CurrencyTypeId = investment.CurrencyTypeId,
            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.EditAsync(id, investmentSaveDto);

            // Assert

            Assert.Equal(investment.Id, investmentDto.Id);
        }

        [Fact]
        public async void returnInvestmentDtoWhenDisabledAsync()
        {
            // Arrage
            int id = 1;
            Investment investment = new()
            {
                Id = id,
                AmountInvestd = 20,
                Description = "Prueba",
                Year = 2023,
                AccreditationCode = "P2023",
                AccountantCode = "P2023",
                MetricTons = "15",
                MonthName = "Octubre",
                MiningConcessionId = 15,
                HolderId = 4,
                InvestmentTypeId = 12,
                CurrencyTypeId = 2,
                State = false,
                RegistrationDate = DateTime.Now
            };
            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);


            // Act

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.DisabledAsync(id);

            // Assert

            Assert.Equal(investment.State, investmentDto.State);
        }
    }
}
