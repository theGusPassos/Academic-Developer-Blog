
export interface IPost {
    id: number;
    title: string;
    content: string;
    author: string;
    date: Date;
    tags: string[];
    comments: IComment[];
}

export interface IComment {
    id: number;
    author: string;
    content: string;
    date: Date;
}