using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;

public class CreateLogMessageTests
{
    
    public Mock<StargateContext> _context = new Mock<StargateContext>();
    public Mock<CreateLogMessage> _createAstronautDuty = new Mock<CreateLogMessage>();

    public CreateLogMessageTests()
    {
        
    }

    [Fact]
    public void VerifyAddLogMessage()
    {
        //Verify that Logs are added when running the command
    }

}