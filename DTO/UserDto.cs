namespace EntityFramework.DTO;

public record UserDto(
    string Name,
    string UserName,
    string Password,
    string Email,
    DateTime BirthDate,
    UserRole UserRole,
    Guid RoleId
);