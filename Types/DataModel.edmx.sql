
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/23/2015 20:58:53
-- Generated from EDMX file: C:\Users\frank\OneDrive\Code\Visual Studio\DesRunningExample\Types\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DesRunningSample];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CourseCalendarEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalendarEntrySet] DROP CONSTRAINT [FK_CourseCalendarEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentExam_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentExam] DROP CONSTRAINT [FK_StudentExam_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentExam_Exam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentExam] DROP CONSTRAINT [FK_StudentExam_Exam];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherCourse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseSet] DROP CONSTRAINT [FK_TeacherCourse];
GO
IF OBJECT_ID(N'[dbo].[FK_ExamCourse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExamSet] DROP CONSTRAINT [FK_ExamCourse];
GO
IF OBJECT_ID(N'[dbo].[FK_Student_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet_Student] DROP CONSTRAINT [FK_Student_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Teacher_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet_Teacher] DROP CONSTRAINT [FK_Teacher_inherits_Person];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CourseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseSet];
GO
IF OBJECT_ID(N'[dbo].[CalendarEntrySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarEntrySet];
GO
IF OBJECT_ID(N'[dbo].[ExamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExamSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet_Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet_Student];
GO
IF OBJECT_ID(N'[dbo].[PersonSet_Teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet_Teacher];
GO
IF OBJECT_ID(N'[dbo].[StudentExam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentExam];
GO
IF OBJECT_ID(N'[dbo].[StudentCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentCourse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CourseSet'
CREATE TABLE [dbo].[CourseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Instance] nvarchar(max)  NOT NULL,
    [InstanceYear] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ECTS] int  NOT NULL,
    [TeacherId] int  NOT NULL
);
GO

-- Creating table 'CalendarEntrySet'
CREATE TABLE [dbo].[CalendarEntrySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Day] int  NOT NULL,
    [StartHour] nvarchar(max)  NOT NULL,
    [EndHour] nvarchar(max)  NOT NULL,
    [CourseId] int  NOT NULL
);
GO

-- Creating table 'ExamSet'
CREATE TABLE [dbo].[ExamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] int  NOT NULL,
    [Grade] int  NOT NULL,
    [Course_Id] int  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FamilyName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonSet_Student'
CREATE TABLE [dbo].[PersonSet_Student] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'PersonSet_Teacher'
CREATE TABLE [dbo].[PersonSet_Teacher] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'StudentExam'
CREATE TABLE [dbo].[StudentExam] (
    [Student_Id] int  NOT NULL,
    [Exam_Id] int  NOT NULL
);
GO

-- Creating table 'StudentCourse'
CREATE TABLE [dbo].[StudentCourse] (
    [Student_Id] int  NOT NULL,
    [Course_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [PK_CourseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CalendarEntrySet'
ALTER TABLE [dbo].[CalendarEntrySet]
ADD CONSTRAINT [PK_CalendarEntrySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExamSet'
ALTER TABLE [dbo].[ExamSet]
ADD CONSTRAINT [PK_ExamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet_Student'
ALTER TABLE [dbo].[PersonSet_Student]
ADD CONSTRAINT [PK_PersonSet_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet_Teacher'
ALTER TABLE [dbo].[PersonSet_Teacher]
ADD CONSTRAINT [PK_PersonSet_Teacher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Student_Id], [Exam_Id] in table 'StudentExam'
ALTER TABLE [dbo].[StudentExam]
ADD CONSTRAINT [PK_StudentExam]
    PRIMARY KEY CLUSTERED ([Student_Id], [Exam_Id] ASC);
GO

-- Creating primary key on [Student_Id], [Course_Id] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [PK_StudentCourse]
    PRIMARY KEY CLUSTERED ([Student_Id], [Course_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CourseId] in table 'CalendarEntrySet'
ALTER TABLE [dbo].[CalendarEntrySet]
ADD CONSTRAINT [FK_CourseCalendarEntry]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseCalendarEntry'
CREATE INDEX [IX_FK_CourseCalendarEntry]
ON [dbo].[CalendarEntrySet]
    ([CourseId]);
GO

-- Creating foreign key on [Student_Id] in table 'StudentExam'
ALTER TABLE [dbo].[StudentExam]
ADD CONSTRAINT [FK_StudentExam_Student]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[PersonSet_Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Exam_Id] in table 'StudentExam'
ALTER TABLE [dbo].[StudentExam]
ADD CONSTRAINT [FK_StudentExam_Exam]
    FOREIGN KEY ([Exam_Id])
    REFERENCES [dbo].[ExamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentExam_Exam'
CREATE INDEX [IX_FK_StudentExam_Exam]
ON [dbo].[StudentExam]
    ([Exam_Id]);
GO

-- Creating foreign key on [Student_Id] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Student]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[PersonSet_Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Course_Id] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Course]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourse_Course'
CREATE INDEX [IX_FK_StudentCourse_Course]
ON [dbo].[StudentCourse]
    ([Course_Id]);
GO

-- Creating foreign key on [TeacherId] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [FK_TeacherCourse]
    FOREIGN KEY ([TeacherId])
    REFERENCES [dbo].[PersonSet_Teacher]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherCourse'
CREATE INDEX [IX_FK_TeacherCourse]
ON [dbo].[CourseSet]
    ([TeacherId]);
GO

-- Creating foreign key on [Course_Id] in table 'ExamSet'
ALTER TABLE [dbo].[ExamSet]
ADD CONSTRAINT [FK_ExamCourse]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExamCourse'
CREATE INDEX [IX_FK_ExamCourse]
ON [dbo].[ExamSet]
    ([Course_Id]);
GO

-- Creating foreign key on [Id] in table 'PersonSet_Student'
ALTER TABLE [dbo].[PersonSet_Student]
ADD CONSTRAINT [FK_Student_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PersonSet_Teacher'
ALTER TABLE [dbo].[PersonSet_Teacher]
ADD CONSTRAINT [FK_Teacher_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------