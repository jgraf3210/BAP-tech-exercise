using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;

public class UpdatePersonTests
{
    private readonly List<Person> _people = new()
    {
        new()
        {
            Id = 1,
            Name = "Old Name"
        }
    };

    private readonly Mock<StargateContext> _context;

    public UpdatePersonTests()
    {
        var options = new DbContextOptionsBuilder<StargateContext>().Options;
        _context = new Mock<StargateContext>(options);
        _context.Setup(context => context.People)
                .Returns(CreatePeopleSet(_people.AsQueryable()).Object);
    }

    [Fact]
    public async Task VerifyUpdate()
    {
        var processor = new UpdatePersonPreProcessor(_context.Object);

        await processor.Process(
            new UpdatePerson { Name = "Old Name" },
            CancellationToken.None);

        _context.Verify(context => context.People, Times.Once);
    }


    [Fact]
    public async Task VerifyBadRequestWhenPersonNotExists()
    {
        var processor = new UpdatePersonPreProcessor(_context.Object);

        var exception = await Assert.ThrowsAsync<BadHttpRequestException>(() =>
            processor.Process(
                new UpdatePerson { Name = "Unknown Person" },
                CancellationToken.None));

        Assert.Equal(400, exception.StatusCode);
        Assert.Equal("Person with that name does not exist", exception.Message);
    }

    private static Mock<DbSet<Person>> CreatePeopleSet(IQueryable<Person> people)
    {
        var peopleSet = new Mock<DbSet<Person>>();
        peopleSet.As<IQueryable<Person>>().Setup(set => set.Provider).Returns(people.Provider);
        peopleSet.As<IQueryable<Person>>().Setup(set => set.Expression).Returns(people.Expression);
        peopleSet.As<IQueryable<Person>>().Setup(set => set.ElementType).Returns(people.ElementType);
        peopleSet.As<IQueryable<Person>>().Setup(set => set.GetEnumerator()).Returns(() => people.GetEnumerator());

        return peopleSet;
    }
}