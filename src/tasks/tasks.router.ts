import { Router, Response, Request } from "express";

// Fire the router function
export const tasksRouter: Router = Router();

// Create default route
tasksRouter.get('/tasks',(req: Request, res: Response)=>{
    res.send('Express + TypeScript Server');
})