<h1># WeBooking</h1>
<h2> Web API project to booking a room in a hotel based on some datetime business rules.</h2>
<br/>
It was also developped a Unit Test project using MS Test to assure that business rules meets the requirements.

<br/>

<h2> GET Reservations (EXTRA) </h2>
<b>Note: As this app doesn't have database to store data. this get reservation method will works after uncomment mock code on BookingBO.cs constructor.</b>
<br/><br/>
URL example - https://localhost:44314/api/booking/reservations
<br/> Parameter: It is not necessarry.

![getreservations](https://user-images.githubusercontent.com/9018950/114430194-9314a180-9b94-11eb-9956-1542d6f7be7e.png)

<br/>

<h2> GET Room availability </h2>
<b>Note: Pass the Start date and End date to know if this date range is available or already booked. Remembering the requirement - "All reservations start at least the next day of booking". </b> <br/><br/>
URL example - https://localhost:44314/api/booking/roomstatus
<br/> Parameter: Start date and End date to see the availabiLike bellow
<br/><br/>
{
    "startDate": "2021-04-06T00:00:00",
    "endDate": "2021-04-07T00:00:00"
}
<br/> Parameter: It is not necessarry.

![getroomstatus](https://user-images.githubusercontent.com/9018950/114431947-7b3e1d00-9b96-11eb-9a81-ddcdc30ef358.png)

<br/>

//TODO - OTHERS API METHODS
