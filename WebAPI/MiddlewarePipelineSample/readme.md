# Middleware Pipeline Sample Project

This project does not follow best practices for middleware security.

It is just a demonstration of how to include some types of validation while building a middleware pipeline.

Please do not take this sample as a standard practice.

## Objectives

- **Mock HTTPS Requirement:** Using a query string parameter to mimic HTTPS-only. The middleware will deny the request if the parameter `protected=true` is not present, simulating an insecure access attempt.
- **Rejection of Unauthorized Requests:** Terminate the pipeline immediately when a request lacks proper authorization.
- **Asynchronous Operations:** Start asynchronous routines to execute I/O tasks without blocking parallel requests.
- **Request Data Validation:** Validate data received from request and sanitize any potentially harmful input.
- **Early Authentication Validation:** Execute authentication validation at the beginning to block users who are not logged in.
- **Security Incident Recording:** Log details about any denied or failed requests for security auditing.


## Conditions and expected responses

| Condition                           | URL Example                                                | Expected Response |
| - | - | - |
| **Mock HTTPS Requirement**          | `http://localhost:5294/`                                   | "HTTPS-only mocked" (400) |
| **Authenticated Request**           | `http://localhost:5294/?protected=true&userlogged=true`    | "Asynchronous task completed" + "Middleware pipeline completed" |
| **Unauthorized Requests**           | `http://localhost:5294/admin-panel?protected=true`         | "Unauthorized user" (401) |
| **Request Data Validation**         | `http://localhost:5294/?protected=true&search=<script>`    | "Invalid request data" (400) |
| **Early Authentication Validation** | `http://localhost:5294/?protected=true`                    | "User not logged on" (403) |
| **Security Incident Recording**     | Requests blocked with 400+ status                          | Security logs show on console |


## Test Cases

**Mock HTTPS Requirement Test:**
- **Purpose:** To ensure middleware is blocking requests that don't include `?protected=true`, mocking HTTPS-only requirement.
- **Execution:** Access URL `http://localhost:5294/`
- **Expected Result:** "HTTPS-only mocked" with status code 400.

**Authenticated Request Test:**
- **Purpose:** Validates that asynchronous operations are executed and final pipeline middleware runs as well.
- **Execution:** Access URL `http://localhost:5294/?protected=true&userlogged=true`
- **Expected Result:** "Asynchronous task completed" and "Middleware pipeline completed" messages in the body.

**Unauthorized Requests Test:**
- **Purpose:** Validates that users performing requests to unauthorized areas are blocked early in the pipeline.
- **Execution:** Access URL `http://localhost:5294/admin-panel?protected=true`
- **Expected Result:** "Unauthorized user" with status code 401.

**Request Data Test:**
- **Purpose:** Validates request data and blocks harmful input, like JavaScript or HTML.
- **Execution:** Access URL `http://localhost:5294/?protected=true&search=<script>`
- **Expected Result:** "Invalid request data" with status code 400.

**Early Authentication Test:**
- **Purpose:** Simulates authentication control, blocking requests from users that are not logged on by default.
- **Execution:** Access URL `http://localhost:5294/?secure=true`
- **Expected Result:** "User not logged on" with status code 403.

**Security Incident Recording Test:**
- **Purpose:** Verify that the middleware is registering security incident occurences, which could be reviewed while auditing.
- **Execution:** Requests that end with status code 400 or higher, like all tests above except **Authenticated Request Test**.
- **Expected Result:** On Visual Studio output check for messages in the format:
    - `[Security] Route: /admin-panel | Status: 401 |`
