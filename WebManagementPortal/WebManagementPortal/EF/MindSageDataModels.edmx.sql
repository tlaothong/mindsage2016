
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/07/2016 09:19:14
-- Generated from EDMX file: D:\Work\mindsage2016\WebManagementPortal\WebManagementPortal\EF\MindSageDataModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MINDSAGE_COURSECATALOG_V0090];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CourseCatalogSemester]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Semesters] DROP CONSTRAINT [FK_CourseCatalogSemester];
GO
IF OBJECT_ID(N'[dbo].[FK_SemesterUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Units] DROP CONSTRAINT [FK_SemesterUnit];
GO
IF OBJECT_ID(N'[dbo].[FK_UnitLesson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lessons] DROP CONSTRAINT [FK_UnitLesson];
GO
IF OBJECT_ID(N'[dbo].[FK_LessonAdvertisement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advertisements] DROP CONSTRAINT [FK_LessonAdvertisement];
GO
IF OBJECT_ID(N'[dbo].[FK_LessonTopicOfTheDay]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicOfTheDays] DROP CONSTRAINT [FK_LessonTopicOfTheDay];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractLicense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licenses] DROP CONSTRAINT [FK_ContractLicense];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseCatalogLicense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licenses] DROP CONSTRAINT [FK_CourseCatalogLicense];
GO
IF OBJECT_ID(N'[dbo].[FK_LicenseTeacherKey]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeacherKeys] DROP CONSTRAINT [FK_LicenseTeacherKey];
GO
IF OBJECT_ID(N'[dbo].[FK_AssessmentItemAssessment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assessments] DROP CONSTRAINT [FK_AssessmentItemAssessment];
GO
IF OBJECT_ID(N'[dbo].[FK_AssessmentChoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Choices] DROP CONSTRAINT [FK_AssessmentChoice];
GO
IF OBJECT_ID(N'[dbo].[FK_LessonAssessmentItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssessmentItems] DROP CONSTRAINT [FK_LessonAssessmentItem];
GO
IF OBJECT_ID(N'[dbo].[FK_LessonAssessmentItem1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssessmentItems] DROP CONSTRAINT [FK_LessonAssessmentItem1];
GO
IF OBJECT_ID(N'[dbo].[FK_LessonLessonItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LessonItems] DROP CONSTRAINT [FK_LessonLessonItem];
GO
IF OBJECT_ID(N'[dbo].[FK_LessonLessonItem1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LessonItems] DROP CONSTRAINT [FK_LessonLessonItem1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CourseCatalogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseCatalogs];
GO
IF OBJECT_ID(N'[dbo].[Semesters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Semesters];
GO
IF OBJECT_ID(N'[dbo].[Units]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Units];
GO
IF OBJECT_ID(N'[dbo].[Lessons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lessons];
GO
IF OBJECT_ID(N'[dbo].[Advertisements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Advertisements];
GO
IF OBJECT_ID(N'[dbo].[TopicOfTheDays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TopicOfTheDays];
GO
IF OBJECT_ID(N'[dbo].[Contracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contracts];
GO
IF OBJECT_ID(N'[dbo].[Licenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Licenses];
GO
IF OBJECT_ID(N'[dbo].[TeacherKeys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeacherKeys];
GO
IF OBJECT_ID(N'[dbo].[ImportContentConfigurations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImportContentConfigurations];
GO
IF OBJECT_ID(N'[dbo].[LessonItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LessonItems];
GO
IF OBJECT_ID(N'[dbo].[AssessmentItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssessmentItems];
GO
IF OBJECT_ID(N'[dbo].[Assessments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Assessments];
GO
IF OBJECT_ID(N'[dbo].[Choices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Choices];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CourseCatalogs'
CREATE TABLE [dbo].[CourseCatalogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupName] varchar(255)  NOT NULL,
    [Grade] int  NOT NULL,
    [Advertisements] varchar(max)  NOT NULL,
    [SideName] varchar(255)  NOT NULL,
    [PriceUSD] float  NOT NULL,
    [Series] varchar(255)  NOT NULL,
    [Title] varchar(255)  NOT NULL,
    [FullDescription] varchar(max)  NOT NULL,
    [DescriptionImageUrl] varchar(max)  NOT NULL,
    [TotalWeeks] int  NOT NULL,
    [IsFree] bit  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL
);
GO

-- Creating table 'Semesters'
CREATE TABLE [dbo].[Semesters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(255)  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [TotalWeeks] int  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL,
    [CourseCatalogId] int  NOT NULL
);
GO

-- Creating table 'Units'
CREATE TABLE [dbo].[Units] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(255)  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [TotalWeeks] int  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL,
    [SemesterId] int  NOT NULL
);
GO

-- Creating table 'Lessons'
CREATE TABLE [dbo].[Lessons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(255)  NOT NULL,
    [IsPreviewable] bit  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL,
    [UnitId] int  NOT NULL
);
GO

-- Creating table 'Advertisements'
CREATE TABLE [dbo].[Advertisements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImageUrl] varchar(max)  NOT NULL,
    [LinkUrl] varchar(max)  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL,
    [LessonId] int  NOT NULL
);
GO

-- Creating table 'TopicOfTheDays'
CREATE TABLE [dbo].[TopicOfTheDays] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] varchar(max)  NOT NULL,
    [SendOnDay] int  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL,
    [LessonId] int  NOT NULL
);
GO

-- Creating table 'Contracts'
CREATE TABLE [dbo].[Contracts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SchoolName] varchar(255)  NOT NULL,
    [City] varchar(50)  NOT NULL,
    [State] varchar(50)  NOT NULL,
    [ZipCode] varchar(50)  NOT NULL,
    [PrimaryContractName] varchar(255)  NOT NULL,
    [PrimaryPhoneNumber] varchar(50)  NOT NULL,
    [PrimaryEmail] varchar(50)  NOT NULL,
    [SecondaryContractName] varchar(255)  NULL,
    [SecondaryPhoneNumber] varchar(50)  NULL,
    [SecondaryEmail] varchar(50)  NULL,
    [StartDate] datetime  NOT NULL,
    [ExpiredDate] datetime  NOT NULL,
    [TimeZone] varchar(255)  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL
);
GO

-- Creating table 'Licenses'
CREATE TABLE [dbo].[Licenses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CourseName] varchar(255)  NOT NULL,
    [Grade] varchar(50)  NOT NULL,
    [StudentsCapacity] int  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL,
    [ContractId] int  NOT NULL,
    [CourseCatalogId] int  NOT NULL
);
GO

-- Creating table 'TeacherKeys'
CREATE TABLE [dbo].[TeacherKeys] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Grade] varchar(50)  NOT NULL,
    [Code] varchar(50)  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL,
    [LicenseId] int  NOT NULL
);
GO

-- Creating table 'ImportContentConfigurations'
CREATE TABLE [dbo].[ImportContentConfigurations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BaseURL] varchar(max)  NOT NULL,
    [HomePageURL] varchar(max)  NOT NULL,
    [PagesURLs] varchar(max)  NOT NULL,
    [ReferenceFileURLs] varchar(max)  NOT NULL,
    [ReplaceSections] varchar(max)  NOT NULL,
    [StorageInfo] varchar(max)  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL
);
GO

-- Creating table 'LessonItems'
CREATE TABLE [dbo].[LessonItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Order] int  NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [IconURL] varchar(255)  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [IsPreviewable] bit  NOT NULL,
    [ContentType] varchar(100)  NOT NULL,
    [ContentURL] varchar(max)  NULL,
    [TeacherLessonId] int  NULL,
    [StudentLessonId] int  NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL
);
GO

-- Creating table 'AssessmentItems'
CREATE TABLE [dbo].[AssessmentItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Order] int  NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [IconURL] varchar(255)  NOT NULL,
    [IsPreviewable] bit  NOT NULL,
    [PreLessonId] int  NULL,
    [PostLessonId] int  NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL
);
GO

-- Creating table 'Assessments'
CREATE TABLE [dbo].[Assessments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Order] int  NOT NULL,
    [ContentType] varchar(100)  NOT NULL,
    [Question] varchar(max)  NOT NULL,
    [StatementBefore] varchar(max)  NULL,
    [StatementAfter] varchar(max)  NULL,
    [AssessmentItemId] int  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL
);
GO

-- Creating table 'Choices'
CREATE TABLE [dbo].[Choices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [IsCorrect] bit  NOT NULL,
    [AssessmentId] int  NOT NULL,
    [RecLog_CreatedDate] datetime  NOT NULL,
    [RecLog_DeletedDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CourseCatalogs'
ALTER TABLE [dbo].[CourseCatalogs]
ADD CONSTRAINT [PK_CourseCatalogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Semesters'
ALTER TABLE [dbo].[Semesters]
ADD CONSTRAINT [PK_Semesters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Units'
ALTER TABLE [dbo].[Units]
ADD CONSTRAINT [PK_Units]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lessons'
ALTER TABLE [dbo].[Lessons]
ADD CONSTRAINT [PK_Lessons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Advertisements'
ALTER TABLE [dbo].[Advertisements]
ADD CONSTRAINT [PK_Advertisements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TopicOfTheDays'
ALTER TABLE [dbo].[TopicOfTheDays]
ADD CONSTRAINT [PK_TopicOfTheDays]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [PK_Contracts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Licenses'
ALTER TABLE [dbo].[Licenses]
ADD CONSTRAINT [PK_Licenses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeacherKeys'
ALTER TABLE [dbo].[TeacherKeys]
ADD CONSTRAINT [PK_TeacherKeys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ImportContentConfigurations'
ALTER TABLE [dbo].[ImportContentConfigurations]
ADD CONSTRAINT [PK_ImportContentConfigurations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LessonItems'
ALTER TABLE [dbo].[LessonItems]
ADD CONSTRAINT [PK_LessonItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AssessmentItems'
ALTER TABLE [dbo].[AssessmentItems]
ADD CONSTRAINT [PK_AssessmentItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Assessments'
ALTER TABLE [dbo].[Assessments]
ADD CONSTRAINT [PK_Assessments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Choices'
ALTER TABLE [dbo].[Choices]
ADD CONSTRAINT [PK_Choices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CourseCatalogId] in table 'Semesters'
ALTER TABLE [dbo].[Semesters]
ADD CONSTRAINT [FK_CourseCatalogSemester]
    FOREIGN KEY ([CourseCatalogId])
    REFERENCES [dbo].[CourseCatalogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseCatalogSemester'
CREATE INDEX [IX_FK_CourseCatalogSemester]
ON [dbo].[Semesters]
    ([CourseCatalogId]);
GO

-- Creating foreign key on [SemesterId] in table 'Units'
ALTER TABLE [dbo].[Units]
ADD CONSTRAINT [FK_SemesterUnit]
    FOREIGN KEY ([SemesterId])
    REFERENCES [dbo].[Semesters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SemesterUnit'
CREATE INDEX [IX_FK_SemesterUnit]
ON [dbo].[Units]
    ([SemesterId]);
GO

-- Creating foreign key on [UnitId] in table 'Lessons'
ALTER TABLE [dbo].[Lessons]
ADD CONSTRAINT [FK_UnitLesson]
    FOREIGN KEY ([UnitId])
    REFERENCES [dbo].[Units]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitLesson'
CREATE INDEX [IX_FK_UnitLesson]
ON [dbo].[Lessons]
    ([UnitId]);
GO

-- Creating foreign key on [LessonId] in table 'Advertisements'
ALTER TABLE [dbo].[Advertisements]
ADD CONSTRAINT [FK_LessonAdvertisement]
    FOREIGN KEY ([LessonId])
    REFERENCES [dbo].[Lessons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LessonAdvertisement'
CREATE INDEX [IX_FK_LessonAdvertisement]
ON [dbo].[Advertisements]
    ([LessonId]);
GO

-- Creating foreign key on [LessonId] in table 'TopicOfTheDays'
ALTER TABLE [dbo].[TopicOfTheDays]
ADD CONSTRAINT [FK_LessonTopicOfTheDay]
    FOREIGN KEY ([LessonId])
    REFERENCES [dbo].[Lessons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LessonTopicOfTheDay'
CREATE INDEX [IX_FK_LessonTopicOfTheDay]
ON [dbo].[TopicOfTheDays]
    ([LessonId]);
GO

-- Creating foreign key on [ContractId] in table 'Licenses'
ALTER TABLE [dbo].[Licenses]
ADD CONSTRAINT [FK_ContractLicense]
    FOREIGN KEY ([ContractId])
    REFERENCES [dbo].[Contracts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractLicense'
CREATE INDEX [IX_FK_ContractLicense]
ON [dbo].[Licenses]
    ([ContractId]);
GO

-- Creating foreign key on [CourseCatalogId] in table 'Licenses'
ALTER TABLE [dbo].[Licenses]
ADD CONSTRAINT [FK_CourseCatalogLicense]
    FOREIGN KEY ([CourseCatalogId])
    REFERENCES [dbo].[CourseCatalogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseCatalogLicense'
CREATE INDEX [IX_FK_CourseCatalogLicense]
ON [dbo].[Licenses]
    ([CourseCatalogId]);
GO

-- Creating foreign key on [LicenseId] in table 'TeacherKeys'
ALTER TABLE [dbo].[TeacherKeys]
ADD CONSTRAINT [FK_LicenseTeacherKey]
    FOREIGN KEY ([LicenseId])
    REFERENCES [dbo].[Licenses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LicenseTeacherKey'
CREATE INDEX [IX_FK_LicenseTeacherKey]
ON [dbo].[TeacherKeys]
    ([LicenseId]);
GO

-- Creating foreign key on [AssessmentItemId] in table 'Assessments'
ALTER TABLE [dbo].[Assessments]
ADD CONSTRAINT [FK_AssessmentItemAssessment]
    FOREIGN KEY ([AssessmentItemId])
    REFERENCES [dbo].[AssessmentItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssessmentItemAssessment'
CREATE INDEX [IX_FK_AssessmentItemAssessment]
ON [dbo].[Assessments]
    ([AssessmentItemId]);
GO

-- Creating foreign key on [AssessmentId] in table 'Choices'
ALTER TABLE [dbo].[Choices]
ADD CONSTRAINT [FK_AssessmentChoice]
    FOREIGN KEY ([AssessmentId])
    REFERENCES [dbo].[Assessments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssessmentChoice'
CREATE INDEX [IX_FK_AssessmentChoice]
ON [dbo].[Choices]
    ([AssessmentId]);
GO

-- Creating foreign key on [PreLessonId] in table 'AssessmentItems'
ALTER TABLE [dbo].[AssessmentItems]
ADD CONSTRAINT [FK_LessonAssessmentItem]
    FOREIGN KEY ([PreLessonId])
    REFERENCES [dbo].[Lessons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LessonAssessmentItem'
CREATE INDEX [IX_FK_LessonAssessmentItem]
ON [dbo].[AssessmentItems]
    ([PreLessonId]);
GO

-- Creating foreign key on [PostLessonId] in table 'AssessmentItems'
ALTER TABLE [dbo].[AssessmentItems]
ADD CONSTRAINT [FK_LessonAssessmentItem1]
    FOREIGN KEY ([PostLessonId])
    REFERENCES [dbo].[Lessons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LessonAssessmentItem1'
CREATE INDEX [IX_FK_LessonAssessmentItem1]
ON [dbo].[AssessmentItems]
    ([PostLessonId]);
GO

-- Creating foreign key on [TeacherLessonId] in table 'LessonItems'
ALTER TABLE [dbo].[LessonItems]
ADD CONSTRAINT [FK_LessonLessonItem]
    FOREIGN KEY ([TeacherLessonId])
    REFERENCES [dbo].[Lessons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LessonLessonItem'
CREATE INDEX [IX_FK_LessonLessonItem]
ON [dbo].[LessonItems]
    ([TeacherLessonId]);
GO

-- Creating foreign key on [StudentLessonId] in table 'LessonItems'
ALTER TABLE [dbo].[LessonItems]
ADD CONSTRAINT [FK_LessonLessonItem1]
    FOREIGN KEY ([StudentLessonId])
    REFERENCES [dbo].[Lessons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LessonLessonItem1'
CREATE INDEX [IX_FK_LessonLessonItem1]
ON [dbo].[LessonItems]
    ([StudentLessonId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------