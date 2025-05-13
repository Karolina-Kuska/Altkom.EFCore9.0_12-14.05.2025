CREATE OR ALTER PROCEDURE GetUserByType @TYPE nvarchar(max)
                AS
                BEGIN
                    SELECT * FROM [User]
                    WHERE UserType = @TYPE
                END