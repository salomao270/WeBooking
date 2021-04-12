<h1># WeBooking</h1>
<h2> Web API project to book a room in a hotel based on some datetime business rules.</h2>
<br/>

<h2> 1) UNIT TEST (EXTRA) </h2>
<h4>It was also developped a Unit Test project using MS Test to assure that business rules meets the requirements.</h4>

![unitTests](https://user-images.githubusercontent.com/9018950/114437568-1934e600-9b9d-11eb-9263-a92747aa6d95.png)

<br/>

<h2> 2) GET - Reservations (EXTRA) </h2>
<b>Note: As this app doesn't have database to store data, this get reservation method will works with mock code on BookingBO.cs constructor.</b>
<br/><br/>
URL example - https://localhost:44314/api/booking/reservations
<br/> Parameter: It is not necessarry.

![getreservations](https://user-images.githubusercontent.com/9018950/114430194-9314a180-9b94-11eb-9956-1542d6f7be7e.png)

<br/>

<h2> 3) GET - Room availability </h2>
<b>Note: Pass the Start date and End date to know if this date range is available or already booked. Remembering the requirement - "All reservations start at least the next day of booking". </b> <br/><br/>
URL example - https://localhost:44314/api/booking/roomstatus
<br/> Parameter: JSON
<br/>
<br/>&nbsp;{
<br/>&nbsp;&nbsp;    "startDate": "2021-04-06T00:00:00",
<br/>&nbsp;&nbsp;    "endDate": "2021-04-07T00:00:00"
<br/>&nbsp;}

![getroomstatus](https://user-images.githubusercontent.com/9018950/114431947-7b3e1d00-9b96-11eb-9a81-ddcdc30ef358.png)

<br/>

<h2> 4) POST - a reservation in a free date </h2>
<b>Note: The register is saved temporary cause it doesnt have database.</b> <br/><br/>
URL example - https://localhost:44314/api/booking/bookreservation
<br/> Parameter: JSON:
<br/><br/>

```json
{
  "id": 1,
  "customer": {
    "id": 1,
    "name": "sample string 2",
    "dateOfBirth": "2021-04-12T12:02:53.5165882-03:00",
    "phone": "sample string 4",
    "email": "sample string 5",
    "documentNumber": 6
  },
  "room": {
    "id": 1
  },
  "startDate": "2021-04-12T12:02:53.5173569-03:00",
  "endDate": "2021-04-12T12:02:53.5173569-03:00"
}
```

![post](https://user-images.githubusercontent.com/9018950/114440308-564ea780-9ba0-11eb-9bdc-b5ceea681a2a.png)

<br/>


<h2> 5) PUT - change a reservation date </h2>
<b>Note: Pass the Start date and End date to update it. </b> <br/><br/>
URL example - https://localhost:44314/api/booking/changereservation
<br/> Parameter: JSON
<br/><br/>

```json
{
    "id": 3,
    "customer": {
        "id": 3,
        "name": "Mary Williams",
        "dateOfBirth": "1992-02-10T00:00:00",
        "phone": "+1 8000-8000",
        "email": "joseph@email.com",
        "documentNumber": 98765
    },
    "room": {
        "id": 1
    },
    "startDate": "2021-04-11T00:00:00",
    "endDate": "2021-04-13T00:00:00"
}
```
<br/> GET METHOD - To see previous booked date.

![put1](https://user-images.githubusercontent.com/9018950/114443256-d9bdc800-9ba3-11eb-854c-2fc0f9d25f4b.png)

<br/><br/> PUT METHOD - To update that previous date to a new one.

![put2](https://user-images.githubusercontent.com/9018950/114442950-85b2e380-9ba3-11eb-8b2d-c2f0223ecfb8.png)

<br/>


<h2> 6) DELETE </h2>
<br/><br/>
URL example - https://localhost:44314/api/booking/delete?id=3
<br/> Parameter: The id number of the Reservation.
<br/><br/>

![delete](https://user-images.githubusercontent.com/9018950/114443601-4042e600-9ba4-11eb-8cd9-a6ec9a8586fd.png)

<br/>
