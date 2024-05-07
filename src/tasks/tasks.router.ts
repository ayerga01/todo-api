import { Router } from "express"
import { tasksController } from "./tasks.controller"
import { createValidator } from "./tasks.validator"

// Fire the router function
export const tasksRouter: Router = Router()

tasksRouter.get("/tasks", tasksController.getAll)
tasksRouter.post("/tasks", createValidator, tasksController.create)
