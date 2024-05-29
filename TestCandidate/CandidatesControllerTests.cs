using System.Threading.Tasks;
using CandidateApi.Controllers;
using CandidateApi.Services;
using FluentValidation;
using FluentValidation.Results;
using job_candidates.Data;
using job_candidates.DTOS;
using job_candidates.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CandidateApi.Tests
{
    public class CandidatesControllerTests
    {
        private static DbContextOptions<ApplicationDbContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task UpsertCandidate_AddNewCandidate_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<ICandidateService>();
            var mockValidator = new Mock<IValidator<CandidateDto>>();
            mockValidator.Setup(v => v.ValidateAsync(It.IsAny<CandidateDto>(), default))
                         .ReturnsAsync(new ValidationResult());

            var candidateDto = new CandidateDto
            {
                FirstName = "Ahmed",
                LastName = "Morsi",
                Email = "Ahmed.Morsi@Hotmail.com",
                PhoneNumber = "1234567890",
                PreferredCallTime = "9am-5pm",
                LinkedInProfile = "https://www.linkedin.com/in/Morsi",
                GitHubProfile = "https://github.com/Morsi00",
                Comment = "Experienced developer"
            };

            var candidate = new Candidate
            {
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                Email = candidateDto.Email,
                PhoneNumber = candidateDto.PhoneNumber,
                PreferredCallTime = candidateDto.PreferredCallTime,
                LinkedInProfile = candidateDto.LinkedInProfile,
                GitHubProfile = candidateDto.GitHubProfile,
                Comment = candidateDto.Comment
            };

            mockService.Setup(s => s.UpsertCandidateAsync(It.IsAny<CandidateDto>())).ReturnsAsync(candidate);

            var controller = new CandidatesController(mockService.Object, mockValidator.Object);

            // Act
            var result = await controller.UpsertCandidate(candidateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Candidate>(okResult.Value);
            Assert.Equal(candidateDto.Email, returnValue.Email);
        }
    }
}
