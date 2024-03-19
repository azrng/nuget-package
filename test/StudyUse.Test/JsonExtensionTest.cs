namespace StudyUse.Test;

public class ObjectToJsonTests
{
    [Fact]
    public void WhenObjectIsNull_ReturnsNull()
    {
        // Arrange
        object obj = null;

        // Act
        var result = obj.ToJson();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void WhenObjectIsNotNull_ReturnsJsonString()
    {
        // Arrange
        var person = new Person { Id = 1, Name = "John Doe", Age = 30 };

        // Act
        var result = person.ToJson();

        // Assert
        var expectedJson = "{\"Id\":1,\"Name\":\"John Doe\",\"Age\":30}";
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void WhenObjectHasReadOnlyProperties_IgnoresReadOnlyProperties()
    {
        // Arrange
        var person = new Person { Id = 1, Name = "John Doe", Age = 30 };

        // Act
        var result = person.ToJson();

        // Assert
        var expectedJson = "{\"Id\":1,\"Name\":\"John Doe\",\"Age\":30}";
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void WhenObjectHasCycles_IgnoresCycles()
    {
        // Arrange
        var child = new Person { Id = 2, Name = "Child" };

        // Act
        var result = child.ToJson();

        // Assert
        var expectedJson = "{\"Id\":2,\"Name\":\"Child\",\"Age\":0}";
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void WhenObjectHasPropertiesWithDifferentCase_SerializesIgnoreCase()
    {
        // Arrange
        var person = new Person { Id = 1, Name = "John Doe", Age = 30 };

        // Act
        var result = person.ToJson();

        // Assert
        var expectedJson = "{\"Id\":1,\"Name\":\"John Doe\",\"Age\":30}";
        Assert.Equal(expectedJson, result);
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}