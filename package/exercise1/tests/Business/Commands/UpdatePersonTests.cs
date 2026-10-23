using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;

public class UpdatePersonTests
{
    private readonly Mock<StargateContext> _context;

    public Mock<UpdatePerson> _updatePerson = new Mock<UpdatePerson>();

    public UpdatePersonTests()
    {
        
    }

    [Fact]
    public async Task VerifyUpdate()
    {
        //Verify that an Update request processes properly
    }


    [Fact]
    public async Task VerifyBadRequestWhenPersonNotExists()
    {
        //Verify that you receive a BadRequest error when the person does not exist
    }
}