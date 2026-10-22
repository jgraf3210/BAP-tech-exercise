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
        //Verify that a Person is added under happy path conditions
    }

    [Fact]
    public void VerifyBadRequestWhenPersonExists()
    {
        //Verify that a BadRequest error is sent out when the Person already exists in the database
    }

}