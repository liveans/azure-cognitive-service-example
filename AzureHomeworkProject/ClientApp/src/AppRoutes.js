import Comment from "./components/Comment.tsx";
import { Home } from "./components/Home.tsx";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/create-comment',
    element: <Comment />
  }
];

export default AppRoutes;
