# Designing Registeration Application

## Context and Problem Statement

Given the following requirements and notes we need to design the high level design for the registeration application:
>SimonsVoss LSM software exists in several editions. Some of them (eg. Starter or Basic) suggest a simple licensing model. To register the software the user fills a form with fields like Company Name, Contact Person, Email, Address, and License Key. In the current LSM version, the user fills the form and saves the provided data to a License Request File (LRF). The user also gets instructions describing how to deal with the LRF.
---
>The new version of LSM should (besides all other new features) simplify the registration process. The user still fills the form, clicks the *Register* button, and waits until registration accomplished. The registration in such a case goes via a publicly available *Registration Service*.
Although the *Registration Service* is publicly available, it must sign each license using the *License Signature Generator*, which can run in SimonsVoss intranet only.
---
> - RESTful API should be defined for licensing requests from the LSM side
> - Protected Websocket or gRPC API should be defined for communication with the License Signature Generator
> - It should be clear how the license request makes its way from LSM to the License Signature Generator inside the Registration Service
> - Because of security reasons, the License Signature Generator cannot provide a public endpoint for external connections, but it still might establish a permanent connection to Registration Service and process incoming requests. Although License Signature Generator is highly available, it might break the connection and re-establish it a few moments later.
> - The registration can fail because of several reasons:
>   -  Invalid Data (eg. malformed email, missing fields)
>   - Invalid License Key
>   - Failed Signature Generation

## Considered Options

* Building All in one system that combines License management + User Management
* Building Modular system with the following components 
  * License Generation Module (Deployed in protected intranet with limited access to outside world)
  * Public available API for User Management

## Decision Outcome

Chosen option: Building modular system with two compenets:
*  License Generation Engine: 
    * Generates Licenses
    * Communicates generated licenses to ther interested parties (registeration service) via integration events
    * Signing registeration requests 
*  Registeration Service:
    * Publicly available 
    * Recieves licenses registration requests
    * Validates requests (Including input validations, fraud protection)
    * Communicates with License Generation Engine
    * Provides an API to track the status of registration requests 