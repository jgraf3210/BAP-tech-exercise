using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Queries;
using StargateAPI.Business.Data;

public class GetPersonByNameTests
{
    private readonly Mock<StargateContext> _context;
    public Mock<GetPersonByName> _getPersonByName = new Mock<GetPersonByName>();

    
    public GetPersonByNameTests()
    {
        
    }

    [Fact]
    public void VerifyQueryOnlyReturnsRequestedData()
    {
        //Verify that the query only returns specific data when there are multiple records
    }


    [Fact]
    public void VerifyBadRequestWhenPersonDoesNotExist()
    {
        //Verify that a BadRequest error is thrown when the user does not exist
    }

}