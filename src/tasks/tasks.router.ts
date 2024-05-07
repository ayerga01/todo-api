import { Router, Response, Request } from "express"
import { tasksController } from "./tasks.controller"
import { createValidator } from "./tasks.validator"
import { validationResult } from "express-validator"

// Fire the router function
export const tasksRouter: Router = Router()

// Create default route
tasksRouter.get("/tasks", tasksController.getAll)

tasksRouter.post(
    "/tasks",
    createValidator,
    // @ts-ignore
    async (req: Request, res: Response) => {
        const errors = validationResult(req)
        if (!errors.isEmpty()) {
            return res.status(400).json({ errors: errors.array() })
        }
    },
)
