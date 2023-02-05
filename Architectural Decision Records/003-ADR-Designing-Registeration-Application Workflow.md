# Designing Registeration Application Workflow

## Context and Problem Statement

How the registration application will work ?


## Decision Outcome

* The app will manage License Registration Requests, Packages and Features 
* Feature is an extra entity used to just demonstrate the many-to-many relation.
* Package is a Vital to the solution as the licenses will be generated based on the package.
* License is generated from the internal service and an integration event is raised to deliver the license Id and Key to the registration app.

* When a LicenseRegistrationRequest is submitted by LMS the incoming request will be verified. Then a domain model will be created then raising a domin event to (try) to sign the request before saving it to the db. If the signing fails we have two options:
  * Fail and return to user so that the user retries 
  * We can try one of two options:
	* Consider transactional outbox pattern
	* Use Polly for retry for number of times but in the current setup retrying will only delay the saving to DB
* Domain Events implemented locally in ABP are just in-memory events raised when savechanges is being called. Events can be lost if server/application crashes. So I would prefere to have more presisted events.