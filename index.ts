import express, { Express } from "express";
import dotenv from "dotenv";
import { DataSource } from "typeorm";
import cors from "cors";
import bodyParser from "body-parser";
import { Task } from "./src/tasks/tasks.entity";
import { tasksRouter } from "./src/tasks/tasks.router";

// Instantiate express app
const app: Express = express();
dotenv.config();

// Parse request body
app.use(bodyParser.json());

// Use cors intsall types as well
app.use(cors());

// Create Database Connection
export const AppDataSource = new DataSource({
    type: "mysql",
    host: "localhost",
    port: 3307,
    username: process.env.MYSQL_USER,
    password: process.env.MYSQL_PASSWORD,
    database: process.env.MYSQL_DB,
    entities:[Task],
    synchronize: true,
})

// Define server port
const port = process.env.PORT;

AppDataSource.initialize().then(()=>{
    // Start listening to the requests on the defined port
    app.listen(port);
    console.log("Data Source has been initialized!");
}).catch((err)=>{
    console.log("Error during Data Source inizialization", err);
});

app.use('/', tasksRouter);