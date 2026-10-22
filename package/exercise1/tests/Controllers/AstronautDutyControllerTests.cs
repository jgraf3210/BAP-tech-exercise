using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;


public class AstronautDutyControllerTests
{
    
    public Mock<StargateContext> _context = new Mock<StargateContext>();


    public AstronautDutyControllerTests()
    {
        
    }

    [Fact]
    public void VerifySuccessLogWhenNoError()
    {
        //Verify that methods create a Success Log when no errors occur
    }

    [Fact]
    public void VerifyLogWhenReceiveBadRequestError()
    {
        //Verify that methods create a BadRequest Log when a BadRequest error occurs
    }

    [Fact]
    public void VerifyLogWhenReceiveInternalServerError()
    {
        //Verify that methods create a InternalServerError Log when a non-BadRequest error occurs
    }

}