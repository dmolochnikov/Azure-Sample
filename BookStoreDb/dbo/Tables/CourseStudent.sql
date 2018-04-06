CREATE TABLE [dbo].[CourseStudent] (
    [CourseId]  INT NOT NULL,
    [StudentId] INT NOT NULL,
    CONSTRAINT [PK_dbo.CourseStudent] PRIMARY KEY CLUSTERED ([CourseId] ASC, [StudentId] ASC),
    CONSTRAINT [FK_dbo.CourseStudent_dbo.Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.CourseStudent_dbo.Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
);

