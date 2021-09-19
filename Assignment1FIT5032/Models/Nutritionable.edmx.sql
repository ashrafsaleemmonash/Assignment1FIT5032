
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/19/2021 17:16:24
-- Generated from EDMX file: C:\Users\ashra\source\repos\Assignment1FIT5032\Assignment1FIT5032\Models\Nutritionable.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-Assignment1FIT5032-20210919075435];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Nutritional_Value]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nutritional_Value];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Nutritional_Value'
CREATE TABLE [dbo].[Nutritional_Value] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Food] nvarchar(max)  NOT NULL,
    [Serving_Gram] float  NOT NULL,
    [Calories] float  NOT NULL,
    [Calories_From_Fat] float  NOT NULL,
    [Total_Fat_Gram] float  NOT NULL,
    [Total_Fat_Daily_Value_By_Precentage] float  NOT NULL,
    [Sodium_Gram] float  NOT NULL,
    [Sodium_Daily_Value_By_Precentage] float  NOT NULL,
    [Potassium_Gram] float  NOT NULL,
    [Potassium_Daily_Value_By_Precentage] float  NOT NULL,
    [Total_Carbo_Hydrate_Gram] float  NOT NULL,
    [Total_Carbo_Hydrate_Daily_Value_By_Precentage] float  NOT NULL,
    [Dietary_Fiber_Gram] float  NOT NULL,
    [Dietary_Fiber_Daily_Value_By_Precentage] float  NOT NULL,
    [Sugar_Gram] float  NOT NULL,
    [Protein_Gram] float  NOT NULL,
    [Vitamin_A_Daily_Value_By_Precentage] float  NOT NULL,
    [Vitamin_C_Daily_Value_By_Precentage] float  NOT NULL,
    [Calcium_Daily_Value_By_Precentage] float  NOT NULL,
    [Iron_Daily_Value_By_Precentage] float  NOT NULL,
    [Saturated_Daily_Value_By_Precentage] float  NULL,
    [Saturated_Milligram] float  NULL,
    [Chole_Sterol_Daily_Value_By_Precentage] float  NOT NULL,
    [Chole_Sterol_Milligram] float  NOT NULL,
    [Food_Type] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Nutritional_Value'
ALTER TABLE [dbo].[Nutritional_Value]
ADD CONSTRAINT [PK_Nutritional_Value]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------