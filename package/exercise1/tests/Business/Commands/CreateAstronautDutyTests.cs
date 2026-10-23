using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;

public class CreateAstronautDutyTests
{
    
    public Mock<StargateContext> _context = new Mock<StargateContext>();
    public Mock<CreateAstronautDuty> _createAstronautDuty = new Mock<CreateAstronautDuty>();
    
    public CreateAstronautDutyTests()
    {
        
    }

    [Fact]
    public void VerifyAdd()
    {
        //Write test to verify that AstronautDutys are added under happy path
    }

    [Fact]
    public void VerifyBadRequestWhenDutyExists()
    {
        //Verify that a BadRequest error is sent when a Person already has an assigned AstronautDuty
    }

    [Fact]
    public void VerifyBadRequestWhenPersonNotExists()
    {
        //Verify that a BadRequest error is sent when the Person does not exist        
    }


}