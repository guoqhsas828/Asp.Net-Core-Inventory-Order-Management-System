CREATE TABLE [TodoItems] (
    [TodoItemId] int NOT NULL IDENTITY,
    [OwnerId] nvarchar(900) NULL,
    [IsDone] bit NOT NULL,
    [Title] nvarchar(1024) NOT NULL,
    [DueAt] datetimeoffset NOT NULL,
    CONSTRAINT [PK_TodoItems] PRIMARY KEY ([TodoItemId])
);

GO