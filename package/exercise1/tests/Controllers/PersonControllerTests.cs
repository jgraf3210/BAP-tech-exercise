using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;

public class PersonControllerTests
{
    public Mock<StargateContext> _context = new Mock<StargateContext>();

    public PersonControllerTests()
    {
        
    }

    [Fact]
    public void VerifyNoLogWhenNoError()
    {

    }

    [Fact]
    public void VerifyLogWhenReceiveBadRequestError()
    {

    }

    [Fact]
    public void VerifyLogWhenReceiveInternalServerError()
    {

    }
}