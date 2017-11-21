﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Xunit;

namespace Microsoft.OpenApi.Tests.Models
{
    public class OpenApiLicenseTests
    {
        public static OpenApiLicense BasicLicense = new OpenApiLicense()
        {
            Name = "Apache 2.0"
        };
        public static OpenApiLicense AdvanceLicense = new OpenApiLicense()
        {
            Name = "Apache 2.0",
            Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html"),
            Extensions = new Dictionary<string, IOpenApiAny>
            {
                { "x-copyright", new OpenApiString("Abc") }
            }
        };

        [Theory]
        [InlineData(OpenApiSpecVersion.OpenApi3_0_0)]
        [InlineData(OpenApiSpecVersion.OpenApi2_0)]
        public void SerializeBasicLicenseAsJsonWorks(OpenApiSpecVersion version)
        {
            // Arrange
            string expected =
@"{
  ""name"": ""Apache 2.0""
}";

            // Act
            string actual = BasicLicense.SerializeAsJson(version);

            // Assert
            actual = actual.MakeLineBreaksEnvironmentNeutral();
            expected = expected.MakeLineBreaksEnvironmentNeutral();
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(OpenApiSpecVersion.OpenApi3_0_0)]
        [InlineData(OpenApiSpecVersion.OpenApi2_0)]
        public void SerializeBasicLicenseAsYamlWorks(OpenApiSpecVersion version)
        {
            // Arrange
            string expected = "name: Apache 2.0";

            // Act
            string actual = BasicLicense.SerializeAsYaml(version);

            // Assert
            actual = actual.MakeLineBreaksEnvironmentNeutral();
            expected = expected.MakeLineBreaksEnvironmentNeutral();
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(OpenApiSpecVersion.OpenApi3_0_0)]
        [InlineData(OpenApiSpecVersion.OpenApi2_0)]
        public void SerializeAdvanceLicenseAsJsonWorks(OpenApiSpecVersion version)
        {
            // Arrange
            string expected = 
@"{
  ""name"": ""Apache 2.0"",
  ""url"": ""http://www.apache.org/licenses/LICENSE-2.0.html"",
  ""x-copyright"": ""Abc""
}";

            // Act
            string actual = AdvanceLicense.SerializeAsJson(version);

            // Assert
            actual = actual.MakeLineBreaksEnvironmentNeutral();
            expected = expected.MakeLineBreaksEnvironmentNeutral();
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(OpenApiSpecVersion.OpenApi3_0_0)]
        [InlineData(OpenApiSpecVersion.OpenApi2_0)]
        public void SerializeAdvanceLicenseAsYamlWorks(OpenApiSpecVersion version)
        {
            // Arrange
            string expected = 
@"name: Apache 2.0
url: http://www.apache.org/licenses/LICENSE-2.0.html
x-copyright: Abc";

            // Act
            string actual = AdvanceLicense.SerializeAsYaml(version);

            // Assert
            actual = actual.MakeLineBreaksEnvironmentNeutral();
            expected = expected.MakeLineBreaksEnvironmentNeutral();
            actual.Should().Be(expected);
        }
    }
}
