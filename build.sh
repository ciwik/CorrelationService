#!/usr/bin/env bash

dotnet restore

dotnet build -c Release -f netcoreapp2.0

revision=${TRAVIS_JOB_ID:=1}  