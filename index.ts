// const express = require('express');
import express, { Express, Request, Response } from "express";

// Instantiate express app
const app: Express = express();

// Define server port
const port = 3200;

// Create default route
app.get('/',(req: Request, res: Response)=>{
    res.send('Express + TypeScript Server');
})

// Start listening to the requests on the defined port
app.listen(port);