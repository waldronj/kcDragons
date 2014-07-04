<?php
	$name = $_POST['name'];
	$phone = $_POST['phone'];
	$email = $_POST['email'];
	$message = $_POST['message'];
	
	$mailmessage = "Name: ".$name."<br />";
	$mailmessage .= "Phone: ".$phone."<br />";
	$mailmessage .= "Email: ".$email."<br />";
	$mailmessage .= "Message: ".$message."<br />";
	
	
		
	$header = "MIME-Version: 1.0\r\n";
	$header .= "Content-type: text/html;\r\n";
	$header .= "From: Website <info@example.com>\r\n";	
	
	$ret = mail("contact@gogreen.lk","Message from website",$mailmessage,$header);
	if($ret){
		echo "Mail sent successfully.";
	}
	else{
		echo "Couldn't send your mail now, try again after sometime.";
	}
?>