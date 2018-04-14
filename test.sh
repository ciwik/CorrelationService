#!/usr/bin/env bash

dotnet restore

dotnet test Core.Tests -c Release
dotnet test ApiService.Tests -c Release

revision=${TRAVIS_JOB_ID:=1}  