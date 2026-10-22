using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;

public class CreatePersonTests
{
    public Mock<StargateContext> _context = new Mock<StargateContext>();

    
    public CreatePersonTests()
    {
        
    }


    [Fact]
    public void VerifyAdd()
    {
        // Given
    
        // When
    
        // Then
    }

    public void VerifyBadRequestWhenPersonExists()
    {
        
    }

}