using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;

public class CreateAstronautDutyTests
{
    
    public Mock<StargateContext> _context = new Mock<StargateContext>();


    public CreateAstronautDutyTests()
    {
        
    }


    [Fact]
    public void VerifyAdd()
    {
        // Given
    
        // When
    
        // Then
    }

    public void VerifyBadRequestWhenDutyExists()
    {
        
    }


    public void VerifyBadRequestWhenPersonNotExists()
    {
        
    }


}