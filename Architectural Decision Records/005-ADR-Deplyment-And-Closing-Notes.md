# Deplyment And Closing Notes

## Context and Problem Statement

How to deploy app and DB?

## Considered Options

* Azure SQL DB and Azure Conatiner apps

## Decision Outcome

* DB was deployed successfully and connection string will be sent along with repo url
* Azure container app failed. (Required more debugging). So I setteled for the dockerfile 
* Protobuf file was created but not implemented. I believe I explained how and where to use it in ADR 003
* LicenseRegistationRequest unit tests were skipped due to lack of time.
* DB was seeded and licenses were created with keys: key0 to key99 
* Input Validation was done only minimally not thoroughly