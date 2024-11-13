public static class ServiceRequestIdGenerator
{
    private static int currentRequestId = 0;

    public static int GenerateNewRequestId()
    {
        return ++currentRequestId;
    }
}