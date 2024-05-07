import { Router, Response, Request } from "express";
import { TasksController } from "./tasks.controller";

// Fire the router function
export const tasksRouter: Router = Router();

// Create default route
tasksRouter.get('/tasks', async (req: Request, res: Response)=>{
    // res.send('Express + TypeScript Server');
    const tasksController = new TasksController();
    const allTasks = await tasksController.getAll();
    res.json(allTasks).status(200);
})